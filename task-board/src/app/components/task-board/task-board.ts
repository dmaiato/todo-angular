import { Component, inject, OnInit } from '@angular/core';
import { TaskService } from '../../services/task-service';
import { Task } from '../../models/task.model';
import { TaskCard } from "../task-card/task-card";

@Component({
  selector: 'app-task-board',
  imports: [TaskCard],
  templateUrl: './task-board.html',
  styleUrl: './task-board.css'
})
export class TaskBoard implements OnInit {
  tasks: Task[] = [];
  protected statusList = ['A Fazer', 'Em Andamento', 'Concluído'];

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.taskService.getTasks().subscribe(
      tasks => {this.tasks = tasks;},
    )
  }

  filterTasks(status: string): Task[] {
    return this.tasks.filter(task => task.status === status);
  }
}
