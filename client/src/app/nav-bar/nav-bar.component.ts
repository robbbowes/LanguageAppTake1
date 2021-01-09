import { ElementRef } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserLogin } from '../_models/user/UserLogin';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  // userLogin: UserLogin = { userName: '', password: '' };
  @ViewChild('navBar', { static: false }) navBar: ElementRef;

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    window.addEventListener('scroll', this.fixNav)
  }

  // login() {
  //   this.accountService.login(this.userLogin).subscribe(() => {
  //     this.router.navigateByUrl('/');
  //   }, error => {
  //     console.log(error);
  //   })
  // }

  logout() {
    this.accountService.logout();
  }

  fixNav = () => {
    if (window.scrollY > this.navBar.nativeElement.offsetHeight + 150) {
      this.navBar.nativeElement.classList.add('rjb-active')
    } else {
      this.navBar.nativeElement.classList.remove('rjb-active')
    }
  }

}
