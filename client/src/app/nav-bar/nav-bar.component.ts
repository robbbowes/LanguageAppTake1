import { Component, OnInit } from '@angular/core';
import { AuthenticatedUser } from '../_models/user/AuthenticatedUser';
import { User } from '../_models/user/User';
import { UserLogin } from '../_models/user/UserLogin';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  userLogin: UserLogin = { userName: '', password: '' };

  constructor(public accountService: AccountService) { }

  ngOnInit(): void { }

  login() {
    this.accountService.login(this.userLogin).subscribe()
  }

}
