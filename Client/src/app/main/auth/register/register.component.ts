import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-auth',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    username: ['', [Validators.required, Validators.pattern(/^\w+/)]],
    password: ['', [Validators.required, Validators.minLength(12)]],
    confirmPassword: ['', [Validators.required]]
  });

  // public authType;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {}

  get form() {
    return this.registerForm.controls;
  }

  submit() {
    const creds = {
      email: this.form.email.value,
      password: this.form.password.value
    };

    if (this.registerForm.controls['password'].value.length < 12) {
      this.registerForm.setErrors({ 'pwLength': true });
      return;
    }

    if (this.registerForm.touched && (this.form.password.value !== this.form.confirmPassword.value)) {
      this.registerForm.setErrors({ 'pwMatch': true });
      return;
    }

    if (this.registerForm.controls['email'].invalid || this.registerForm.controls['username'].invalid || this.registerForm.controls['password'].invalid) { 

      this.registerForm.setErrors({ 'notValid': true });
      return;
    }

    this.authService.register(creds).subscribe(
      res => {
        if (res === true) {
          this.router.navigateByUrl('/auth/login');
        }
      },
      err => {
        this.registerForm.setErrors({ 'signupFail': true });
        return;
      }
    );
  }
}
