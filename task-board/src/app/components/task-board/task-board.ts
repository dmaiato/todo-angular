import { Component, inject } from '@angular/core';
import { TaskService } from '../../services/task-service';

@Component({
  selector: 'app-task-board',
  imports: [],
  templateUrl: './task-board.html',
  styleUrl: './task-board.css'
})
export class TaskBoard {
  private taskService = inject(TaskService);
}
