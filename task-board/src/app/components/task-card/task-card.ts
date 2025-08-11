import {
    Component,
    EventEmitter,
    Inject,
    input,
    Input,
    Output,
} from '@angular/core';
import { Task } from '../../models/task.model';
import { TaskService } from '../../services/task-service';

@Component({
    selector: 'app-task-card',
    imports: [],
    templateUrl: './task-card.html',
    styleUrl: './task-card.css',
})
export class TaskCard {
    @Input() task!: Task;
    @Output() edit = new EventEmitter<Task>();
    @Output() delete = new EventEmitter<number>();

    onEdit() {
        this.edit.emit(this.task);
    }

    onDelete() {
        if (confirm('Você tem certeza que deseja excluir esta tarefa?')) {
            this.delete.emit(this.task.id);
        }
    }
}
