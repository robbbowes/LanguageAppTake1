import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserLogin } from '../_models/user/UserLogin';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  userLogin: UserLogin = { userName: '', password: '' };
  registerMode = false;

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.userLogin).subscribe(() => {
      this.router.navigateByUrl('/');
    }, error => {
      console.log(error);
    })
  }

  toggleRegisterMode = () => {
    this.registerMode = !this.registerMode
  }

}
