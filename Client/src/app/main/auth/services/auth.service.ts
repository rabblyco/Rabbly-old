import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginRegister } from '../models/login-register.model';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { InterceptorSkipHeader } from '../../content/authentication.interceptor';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public http: HttpClient) { }

  public login(credentials: LoginRegister): Observable<any> {
    return this.http.post<any>(`${environment.url}/auth/login`, credentials, {
      headers: {
        InterceptorSkipHeader
      }
    });
  }

  public register(credentials: LoginRegister): Observable<any> {
    return this.http.post<any>(`${environment.url}/auth/register`, credentials, {
      headers: {
        InterceptorSkipHeader
      }
    });
  }

  public confirmSocialLogin(email: string): Observable<any> {
    return this.http.post<any>(`${environment.url}/auth/social`, { email });
  }

  public checkLogin(): Observable<any> {
    return this.http.get(`${environment.url}/auth/check`);
  }
}
