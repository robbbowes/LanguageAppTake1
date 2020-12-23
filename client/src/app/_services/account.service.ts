import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'

import { environment } from 'src/environments/environment';
import { ServiceResponse } from '../_models/ServiceResponse';
import { AuthenticatedUser } from '../_models/user/AuthenticatedUser';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl: string = environment.apiUrl;
  private currentUserSource = new ReplaySubject<AuthenticatedUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(userLoginData: any) {
    return this.http.post(this.baseUrl + 'auth/login', userLoginData).pipe(
      map((response: ServiceResponse<AuthenticatedUser>) => {
        const payload = response;
        if (response.success) {
          localStorage.setItem('authenticatedUser', JSON.stringify(payload.data));
          this.currentUserSource.next(payload.data);
        }
      })
    )
  }

  setCurrentUser(user: AuthenticatedUser) {
    this.currentUserSource.next(user);
  }

}
