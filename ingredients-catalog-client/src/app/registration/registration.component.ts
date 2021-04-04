import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from '../services/auth.service';
import {first} from 'rxjs/operators';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  incorrectRegData = false;
  userName = '';
  password = '';
  email = '';
  fullName = '';

  regForm: FormGroup = this.formBuilder.group({
    userName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    fullName: ['', Validators.required],
    password: ['', [Validators.required, Validators.minLength(4)]],
    avatarImage: ['']
  });

  constructor(private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private router: Router,
              private authService: AuthService) {}

  ngOnInit(): void {
    this.incorrectRegData = false;
  }

  onSubmit(): any {
    this.authService.registration({
      userName: this.regForm.value.userName,
      email: this.regForm.value.email,
      fullName: this.regForm.value.fullName,
      password: this.regForm.value.password,
    }).subscribe(
      (res: any) => {
        if (res.succeeded) {
          const returnUrl = '';
          this.authService.login({username: this.userName, password: this.password}).pipe(first())
            .subscribe(
              () => {
                this.router.navigate([returnUrl]);
              });
        }
        else {
          this.incorrectRegData = true;
        }
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

}
