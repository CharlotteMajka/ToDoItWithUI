import {AssigneeModel} from './assignee.model';

export interface TaskModel {
  Description: string;
  Assignee?: AssigneeModel;
  DueDate: Date;
  IsComplete?: boolean;
}
