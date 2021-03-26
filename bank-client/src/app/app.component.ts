import {Component, OnInit} from '@angular/core';
import {AuthService} from "./services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'bank-client';

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem('authToken')) {
      this.authService.setUserDetails();
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(["login"]);
  }

  getAuthService(): AuthService {
    return this.authService;
  }
}
