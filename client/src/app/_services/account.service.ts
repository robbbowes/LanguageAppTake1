import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(private http: HttpClient, private router: Router) { }

  login(userLoginData: any) {
    return this.http.post(this.baseUrl + 'auth/login', userLoginData).pipe(
      map((response: ServiceResponse<AuthenticatedUser>) => {
        if (response.success) {
          localStorage.setItem('authenticatedUser', JSON.stringify(response.data));
          console.log(response)
          this.currentUserSource.next(response.data);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('authenticatedUser');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/auth');
  }

  setCurrentUser(user: AuthenticatedUser) {
    this.currentUserSource.next(user);
  }

}
