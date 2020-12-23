import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'

import { environment } from 'src/environments/environment';
import { AuthenticatedUser } from '../_models/user/AuthenticatedUser';
import { UserLogin } from '../_models/user/UserLogin';

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
      map((response: AuthenticatedUser) => {
        const authenticatedUser = response;
        if (authenticatedUser) {
          localStorage.setItem('authenticatedUser', JSON.stringify(authenticatedUser));
          this.currentUserSource.next(authenticatedUser);
        }
      })
    )
  }

  setCurrentUser(user: AuthenticatedUser) {
    this.currentUserSource.next(user);
  }

}
