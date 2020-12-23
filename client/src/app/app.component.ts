import { Component, OnInit } from '@angular/core';
import { AuthenticatedUser } from './_models/user/AuthenticatedUser';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: AuthenticatedUser = JSON.parse(localStorage.getItem('authenticatedUser'));
    this.accountService.setCurrentUser(user);
  }

}
