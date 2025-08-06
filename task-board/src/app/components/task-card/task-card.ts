import { Component } from '@angular/core';

@Component({
  selector: 'app-task-card',
  imports: [],
  templateUrl: './task-card.html',
  styleUrl: './task-card.css'
})
export class TaskCard {

  protected readonly title: string = "task-card works!";
  protected showTitle: boolean = true;

  handleButtonClick(event: any) {
    event.preventDefault();
    this.showTitle = !this.showTitle
  }
}
