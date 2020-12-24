import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course/Course';
import { ServiceResponse } from '../_models/ServiceResponse';
import { User } from '../_models/user/User';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('authenticatedUser'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCourses(): Observable<ServiceResponse<User>> {
    const userName: string = JSON.parse(localStorage.getItem('authenticatedUser'))?.userName;
    return this.http.get<ServiceResponse<User>>(this.baseUrl + `user/${userName}/course`, httpOptions);
  }

  getCourse(id: number): Observable<ServiceResponse<Course>> {
    return this.http.get<ServiceResponse<Course>>(this.baseUrl + `course/${id}/lesson`);
  }
}
