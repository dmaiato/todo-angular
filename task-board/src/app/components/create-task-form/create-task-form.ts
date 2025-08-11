import { Component, Inject } from '@angular/core';
import {
    FormGroup,
    FormBuilder,
    Validators,
    ReactiveFormsModule,
} from '@angular/forms';
import { Task } from '../../models/task.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
    selector: 'app-create-task-form',
    standalone: true,
    imports: [
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
    ],
    templateUrl: './create-task-form.html',
    styleUrl: './create-task-form.css',
})
export class CreateTaskForm {
    taskForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private dialogRef: MatDialogRef<CreateTaskForm>,
        @Inject(MAT_DIALOG_DATA) public data: { task?: Task }
    ) {
        this.taskForm = this.fb.group({
            title: [data.task?.title || '', Validators.required],
            description: [data.task?.description || ''],
            status: [data.task?.status || 'A Fazer'],
        });
    }

    save() {
        if (this.taskForm.valid) {
            console.log('Form is valid:', this.taskForm.value);
            const result: Task = {
                ...this.data.task,
                ...this.taskForm.value,
            };
            this.dialogRef.close(result);
        }
    }

    cancel() {
        this.dialogRef.close();
    }
}
