import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GroupService {

  constructor(public http: HttpClient) { }

  public getGroups(): Observable<any> {
    return this.http.get(`${environment.url}/group/all`);
  }

  public getGroup(id: string): Observable<any> {
    return this.http.get(`${environment.url}/group/${id}`);
  }
}
