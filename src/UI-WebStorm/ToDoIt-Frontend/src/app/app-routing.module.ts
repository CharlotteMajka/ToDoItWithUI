import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AssigneeComponent} from './assignee/assignee.component';

const routes: Routes = [{path: '', component: AssigneeComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
