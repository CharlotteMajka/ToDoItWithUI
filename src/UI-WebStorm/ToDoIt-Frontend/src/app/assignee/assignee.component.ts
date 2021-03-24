import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import {TaskModel} from '../shared/task.model';

@Component({
  selector: 'app-assignee',
  templateUrl: './assignee.component.html',
  styleUrls: ['./assignee.component.scss']
})
export class AssigneeComponent implements OnInit {
dueDate = new FormControl('');
description = new FormControl('');
responsible = new FormControl('');
taskList: TaskModel[] = [];
  constructor() { }

  ngOnInit(): void {
    const newTask: TaskModel = {
      Assignee: 'Hanne',
      Description: 'Prøve',
      DueDate: '25-03-2021',
      IsComplete: true
    };
    this.taskList.push(newTask);

    const newTask2: TaskModel = {
      Assignee: 'Hans',
      Description: 'test',
      DueDate: '25-04-2021',
      IsComplete: false
    };
    this.taskList.push(newTask2);
  }

  save(): void {
    const newTask: TaskModel = {
      Assignee: this.responsible.value,
      Description: this.description.value,
      DueDate: this.dueDate.value,
      IsComplete: false
    };
    this.taskList.push(newTask);
  }


  Delete(task: TaskModel): void {
    this.taskList = this.taskList.filter(value => value !== task);
  }
}
