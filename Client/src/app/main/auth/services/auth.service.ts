import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginRegister } from '../models/login-register.model';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public http: HttpClient) { }

  public login(credentials: LoginRegister): Observable<any> {
    return this.http.post<any>(`${environment.url}/auth/login`, credentials);
  }

  public register(credentials: LoginRegister): Observable<any> {
    return this.http.post<any>(`${environment.url}/auth/register`, credentials);
  }

  public confirmSocialLogin(email: string): Observable<any> {
    return this.http.post<any>(`${environment.url}/auth/social`, { email });
  }

  public checkLogin() {
    return this.http.get(`${environment.url}/auth/check`,
    {
      headers: {
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }
    });
  }
}
