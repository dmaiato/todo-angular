import { Component, signal } from '@angular/core';
import { TaskCard } from './components/task-card/task-card';
import { TaskBoard } from './components/task-board/task-board';

@Component({
  selector: 'app-root',
  imports: [TaskCard, TaskBoard],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly header = signal('HEADER');
}
