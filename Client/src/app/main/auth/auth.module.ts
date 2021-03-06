import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthRoutingModule } from './auth-routing.module';
import {
  SocialLoginModule,
  AuthServiceConfig,
  GoogleLoginProvider,
  FacebookLoginProvider,
} from 'angular-6-social-login';

export function getAuthServiceConfigs() {
  const config = new AuthServiceConfig(
    [
      {
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider('340114918710-6pebk36f1gccbri0fke24hqold2h058d.apps.googleusercontent.com')
      }
    ]
  );
  return config;
}

@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [
    AuthRoutingModule,
    CommonModule,
    SocialLoginModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
  ],
  exports: [AuthRoutingModule]
})
export class AuthModule { }
