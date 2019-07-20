import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { AuthActions, Login, Logout } from '../../../store/actions/auth.actions';
import { GroupActions, UpdateGroup } from '../../../store/actions/group.actions';
import { ProfileActions, UpdateProfile } from '../../../store/actions/profile.actions';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import {
  AuthService as SocialAuthService,
  FacebookLoginProvider,
  GoogleLoginProvider
} from 'angular-6-social-login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(12)]]
  });

  constructor(
    private authService: AuthService,
    private socialAuthService: SocialAuthService,
    private fb: FormBuilder,
    private router: Router,
    private store: Store<any>
    ) { }

  ngOnInit() {
  }

  get form() {
    return this.loginForm.controls;
  }

  submit() {
    const creds = {
      email: this.form.email.value,
      password: this.form.password.value
    };
    if (this.loginForm.invalid) { return; }
    this.authService.login(creds).toPromise().then(res => {
      this.store.dispatch(new Login());
      return res;
    })
    .then(res => {
      this.store.dispatch(new UpdateProfile(res.user.profile));
      return res;
    })
    .then(res => {
      this.store.dispatch(new UpdateGroup({ group: res.user.group, rank: res.user.rank }));
      localStorage.setItem('token', res.token); ;
      this.router.navigateByUrl('/');
      return res;
    }).catch(err => {
      this.store.dispatch(null);
      this.loginForm.setErrors({
        'loginError': 'Unable to login'
      });
    });
  }

  public socialLogin(socialPlatform: string) {
    let socialPlatformProvider;
    switch (socialPlatform) {
      case 'google':
        socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
        break;
      default:
        break;
    }
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        console.log(socialPlatform + ' sign in data : ' , userData);
        this.authService.confirmSocialLogin(userData.email)
          .subscribe(
            res => {
              console.log('Succ: ', res);
            localStorage.setItem('token', userData.idToken);
            },
            err => {
              console.log('ERR: ', err);
          });
      }
    ).catch(err => console.log('ERR: ', err));
  }

}
