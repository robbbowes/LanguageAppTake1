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
  loading = false;

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe(user => {
      if (user !== null) {
        this.router.navigate(['/']);
      }
    })
  }

  login() {
    this.loading = true;
    this.accountService.login(this.userLogin).subscribe(() => {
      this.router.navigate(['/']);
    }, error => {
      console.log(error);
    })
    this.loading = false;
  }

  register() {
    this.loading = true;
    this.accountService.register(this.userLogin).subscribe(() => {
      this.router.navigate(['/'])
    }, error => {
      console.log(error);
    })
    this.loading = false;
  }

  toggleRegisterMode = () => {
    this.registerMode = !this.registerMode
  }

}
