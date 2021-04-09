import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Task} from './task.model';
import {environment} from '../../environments/environment';
import {Injectable} from '@angular/core';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class TaskAssigneeService {
  constructor(private http: HttpClient ) {
  }

  readTask(): Observable<Task[]>{

    return this.http.get<Task[]>(environment.webApiUrl + 'Task', httpOptions);

  }


}
