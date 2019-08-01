import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments/environment';
import { Profile } from 'src/app/models/profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(public http: HttpClient) { }

  public getProfile(): Observable<Profile> {
    return this.http.get<Profile>(`${environment.url}/profile`);
  }

  public editProfile(profile: Profile): Observable<any> {
    return this.http.patch(`${environment.url}/profile`, profile);
  }
}
