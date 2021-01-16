import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lesson } from '../_models/lesson/Lesson';
import { Sentence } from '../_models/sentence/Sentence';
import { ServiceResponse } from '../_models/ServiceResponse';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getLesson(lessonId: number): Observable<ServiceResponse<Lesson>> {
    return this.http.get<ServiceResponse<Lesson>>(this.baseUrl + "lesson/" + lessonId)
  }

  getLessonWithSentences(lessonId: number): Observable<ServiceResponse<Lesson>> {
    return this.http.get<ServiceResponse<Lesson>>(this.baseUrl + "lesson/" + lessonId + "/sentence")
  }

  addSentence(lessonId: number, sentence: Sentence): Observable<ServiceResponse<number>> {
    return this.http.post<ServiceResponse<number>>(this.baseUrl + "/lesson/" + lessonId, JSON.stringify(sentence))
  }
}
