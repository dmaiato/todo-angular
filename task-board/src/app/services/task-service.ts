import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Task } from '../models/task.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root',
})
export class TaskService {
    private apiUrl = 'http://localhost:5280';
    private tasksSubject = new BehaviorSubject<Task[]>([]);
    tasks$ = this.tasksSubject.asObservable();

    constructor(private http: HttpClient) {
        this.loadTasks();
    }

    private loadTasks(): void {
        this.http
            .get<Task[]>(`${this.apiUrl}/tasks`)
            .subscribe((tasks) => this.tasksSubject.next(tasks));
    }

    createTask(task: Omit<Task, 'id'>): Observable<Task> {
        return this.http
            .post<Task>(`${this.apiUrl}/tasks`, task)
            .pipe(tap(() => this.loadTasks()));
    }

    updateTask(task: Task): Observable<Task> {
        return this.http
            .put<Task>(`${this.apiUrl}/tasks/${task.id}`, task)
            .pipe(tap(() => this.loadTasks()));
    }

    deleteTask(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/tasks/${id}`).pipe(
            tap(() => {
                const currentTasks = this.tasksSubject.getValue();
                this.tasksSubject.next(
                    currentTasks.filter((task) => task.id !== id)
                );
            })
        );
    }

    getTasks(): Observable<Task[]> {
        return this.tasks$;
    }
}
