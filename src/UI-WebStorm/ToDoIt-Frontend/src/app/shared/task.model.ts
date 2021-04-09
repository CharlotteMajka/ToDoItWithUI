import {Assignee} from './assignee.model';

export interface Task {
  taskId?: number;
  description: string;
  assignee?: Assignee;
  isComplete?: boolean;
  dueDate: Date;

}
