import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {Task} from '../shared/task.model';
import {Assignee} from '../shared/assignee.model';
import {Observable} from 'rxjs';
import {TaskAssigneeService} from '../shared/taskAssignee.service';
import {catchError, map, tap} from 'rxjs/operators';

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
  filterDescription = new FormControl('');

taskList: Task[] = [];
assigneeList: Assignee[] = [];
// @ts-ignore
  formGroupUpdate: any;
  private errString: any;
  // @ts-ignore
  taskList$: Observable<Task[]> = [];


  constructor(private fb: FormBuilder, private service: TaskAssigneeService) { }

  ngOnInit(): void {
    // makes formgrup for update modal
    this.formGroupUpdate = this.fb.group({
      Description: [''],
      Assignee: [''],
      DueDate: [''],
    });
    // takes the tasklist$ and puts it in tasklist
    this.taskList$ = this.service.readTask().pipe(
     tap( list => {this.taskList = list;
     }),
      catchError(this.errString)
   );
    // makes the filterform ready to filter on input
    this.filterDescription.valueChanges.subscribe(value => {
      this.taskList.filter(t => t.description.includes(this.filterDescription.value));
    });
    // for debugging
    console.log( JSON.stringify(this.taskList.toString()));
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
    const newAssignee: Assignee = {
      id: this.assigneeList.length + 2,
      name: this.newAsignee.value
    };
    this.assigneeList.push(newAssignee);
  }
  Delete(task: Task): void {
    this.taskList = this.taskList.filter(value => value !== task);
  }

  getUpdateReady(task: Task): void {
  this.formGroupUpdate.patchValue({
    Description: [task.description],
    Assignee: [task.assignee?.id],
    DueDate: [task.dueDate],
  });

  }

  saveUpdate(taskId: Task): void {
    // tslint:disable-next-line:radix
    const assig = this.assigneeList.find((a) => a.id = parseInt(this.formGroupUpdate.Assignee.value.id));

    const tasktoupdate: Task = {
        description: this.formGroupUpdate.description.value,
        assignee:  assig,
        dueDate: this.formGroupUpdate.DueDate.value
    };

    this.taskList = this.taskList.filter( (t) => t !== taskId);

    this.taskList.push(tasktoupdate);

    }
}
