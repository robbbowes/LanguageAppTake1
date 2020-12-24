import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void { }

  login() {
    this.accountService.login(this.userLogin).subscribe(response => {
      this.router.navigateByUrl('/course-list');
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
