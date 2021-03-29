import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {TaskModel} from '../shared/task.model';
import {AssigneeModel} from '../shared/assignee.model';
import {Observable} from 'rxjs';
import {TaskAssigneeService} from '../shared/taskAssignee.service';
import {tap} from 'rxjs/operators';

@Component({
  selector: 'app-assignee',
  templateUrl: './assignee.component.html',
  styleUrls: ['./assignee.component.scss']
})
export class AssigneeComponent implements OnInit {
dueDate = new FormControl('');
description = new FormControl('');
responsible = new FormControl('');
newAsignee = new FormControl('');

taskList: TaskModel[] = [];
assigneeList: AssigneeModel[] = [];
// @ts-ignore
  formGroupUpdate: any;
  private errString: any;
  // @ts-ignore
  taskList$: Observable<TaskModel[]> = [];

  constructor(private fb: FormBuilder, private service: TaskAssigneeService) { }

  ngOnInit(): void {
    this.formGroupUpdate = this.fb.group({
      Description: [''],
      Assignee: [''],
      DueDate: [''],
    });
    this.taskList$ = this.service.readTask().pipe(
     tap( list => {this.taskList = list; })
   );

  }

  save(): void {

    // tslint:disable-next-line:radix
    const assign = this.assigneeList.find((as) => as.id === parseInt(this.responsible.value));
    // @ts-ignore
    const newTask: TaskModel = {

      Assignee: assign,
      Description: this.description.value,
      DueDate: this.dueDate.value,
      IsComplete: false
    };
    this.taskList.push(newTask);
  }

  saveNewAssignee(): void {
    const newAssignee: AssigneeModel = {
      id: this.assigneeList.length + 2,
      name: this.newAsignee.value
    };
    this.assigneeList.push(newAssignee);
  }
  Delete(task: TaskModel): void {
    this.taskList = this.taskList.filter(value => value !== task);
  }

  getUpdateReady(task: TaskModel): void {
  this.formGroupUpdate.patchValue({
    Description: [task.Description],
    Assignee: [task.Assignee?.id],
    DueDate: [task.DueDate],
  });

  }

  saveUpdate(taskId: TaskModel): void {
    // tslint:disable-next-line:radix
    const assig = this.assigneeList.find((a) => a.id = parseInt(this.formGroupUpdate.Assignee.value.id));

    const tasktoupdate: TaskModel = {
        Description: this.formGroupUpdate.Description.value,
        Assignee:  assig,
        DueDate: this.formGroupUpdate.DueDate.value
    };

    this.taskList = this.taskList.filter( (t) => t !== taskId);

    this.taskList.push(tasktoupdate);

    }
}
