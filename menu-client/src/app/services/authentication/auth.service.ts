import { Injectable } from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {User} from '../../Models/user';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userData = new BehaviorSubject<User>(new User());
  private appUrl = environment.authAppUrl;
  private apiUrl = 'api/users';
  isUserLoggedIn = false;

  constructor(private http: HttpClient, private router: Router) { }

  login(userDetails: any): any {
    return this.http.post<any>(this.appUrl + this.apiUrl + '/login', userDetails)
      .pipe(map(response => {
        console.log(userDetails);
        localStorage.setItem('authToken', response.token);
        this.setUserDetails();
        return response;
      }));
  }

  registration(userDetails: any): any {
    return this.http.post<any>(this.appUrl + this.apiUrl + '/registration', userDetails);
  }

  setUserDetails(): void {
    if (localStorage.getItem('authToken')) {
      const userDetails = new User();
      // tslint:disable-next-line:no-non-null-assertion
      const decodeUserDetails = JSON.parse(window.atob(localStorage.getItem('authToken')!.split('.')[1]));

      userDetails.userName = decodeUserDetails.sub;
      userDetails.fullName = decodeUserDetails.fullName;
      userDetails.isLoggedIn = true;
      userDetails.role = decodeUserDetails.role;

      this.isUserLoggedIn = true;
      this.userData.next(userDetails);
    }
  }

  logout(): void {
    localStorage.removeItem('authToken');
    this.isUserLoggedIn = false;
    this.router.navigate(['/']);
    this.userData.next(new User());
  }

  checkLogged(): boolean {
    return this.isUserLoggedIn;
  }

  getUserName(): string {
    return this.userData.value.userName;
  }

  getRole(): string {
    return this.userData.value.role;
  }
}
