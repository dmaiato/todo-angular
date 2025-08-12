import { Component, inject, OnInit } from '@angular/core';
import { TaskService } from '../../services/task-service';
import { Task } from '../../models/task.model';
import { TaskCard } from '../task-card/task-card';
import { MatDialog } from '@angular/material/dialog';
import { CreateTaskForm } from '../create-task-form/create-task-form';

@Component({
    selector: 'app-task-board',
    imports: [TaskCard],
    templateUrl: './task-board.html',
    styleUrl: './task-board.css',
})
export class TaskBoard implements OnInit {
    tasks: Task[] = [];
    protected statusList = ['A Fazer', 'Em Andamento', 'Concluído'];

    constructor(private taskService: TaskService, private dialog: MatDialog) {}

    ngOnInit(): void {
        this.taskService.getTasks().subscribe((tasks) => {
            this.tasks = tasks;
        });
    }

    sortTasksById(tasks: Task[]): Task[] {
        return tasks.sort((a, b) => a.id - b.id);
    }

    filterTasks(status: string): Task[] {
        this.tasks = this.sortTasksById(this.tasks);
        return this.tasks.filter((task) => task.status === status);
    }

    openCreateTaskDialog() {
        const dialogRef = this.dialog.open(CreateTaskForm, {
            data: {},
        });

        dialogRef.afterClosed().subscribe((result: Task | undefined) => {
            if (result) {
                // If result has no id, it's a new task
                this.taskService
                    .createTask({
                        title: result.title,
                        description: result.description,
                        status: result.status,
                    })
                    .subscribe();
            }
        });
    }

    openEditTaskDialog(task: Task) {
        const dialogRef = this.dialog.open(CreateTaskForm, {
            data: { task },
        });

        dialogRef.afterClosed().subscribe((result: Task | undefined) => {
            if (result) this.taskService.updateTask(result).subscribe();
        });
    }

    handleCreateTask() {
        this.openCreateTaskDialog();
    }

    handleEditTask(task: Task) {
        this.openEditTaskDialog(task);
    }

    handleDeleteTask(id: number) {
        this.taskService.deleteTask(id).subscribe();
    }
}
