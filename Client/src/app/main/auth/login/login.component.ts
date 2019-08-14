import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Login } from '../../../store/actions/auth.actions';
import { UpdateGroup } from '../../../store/actions/group.actions';
import { UpdateProfile } from '../../../store/actions/profile.actions';
import { FormBuilder, Validators } from '@angular/forms';
import { UpdateDebates } from '../../../store/actions/debate.actions';
import {
  AuthService as SocialAuthService,
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
    if (this.loginForm.invalid) {
      this.loginForm.setErrors({
        'loginError': 'Invalid email or password'
      });
      return; 
    }
    this.authService.login(creds).subscribe((res: any) => {
        console.log(res);
        this.store.dispatch(new Login());
        this.store.dispatch(new UpdateProfile(res.user.profile));
        this.store.dispatch(new UpdateGroup({ group: res.user.group, rank: res.user.rank }));
        this.store.dispatch(new UpdateDebates({ createdDebates: res.createdDebates, participatingDebates: res.participatingDebates }));
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/');
    }, err => {
      // this.store.dispatch(null);
      this.loginForm.setErrors({
        'loginError': 'Invalid email or password'
      });
      return err;
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
        this.authService.confirmSocialLogin(userData.email).toPromise()
        .then(res => {
          this.store.dispatch(new Login());
          return res;
        })
        .then(res => {
          this.store.dispatch(new UpdateProfile(res.user.profile));
          return res;
        })
        .then(res => {
          this.store.dispatch(new UpdateGroup({ group: res.user.group, rank: res.user.rank }));
          localStorage.setItem('token', res.token);
          this.router.navigateByUrl('/');
          return res;
        })
        .catch(err => {
          // this.store.dispatch(null);
          this.loginForm.setErrors({
            'loginError': 'Invalid email or password'
          });
          return err;
        });
      }
    ).catch(err => console.log('ERR: ', err));
  }

}
