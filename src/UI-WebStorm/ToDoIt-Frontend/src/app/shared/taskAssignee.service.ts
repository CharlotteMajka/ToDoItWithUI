import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {TaskModel} from './task.model';
import {environment} from '../../environments/environment';


export class TaskAssigneeService {

  constructor(private http: HttpClient ) {
  }

  readTask(): Observable<TaskModel[]>{

    return this.http.get<TaskModel[]>(environment.webApiUrl);
  }


}
