import {Task} from './task.model';

export interface Assignee {
  id: number;
  name: string;
  tasks?: Task[];
}
