import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DebateService {

  constructor(public http: HttpClient) { }

  public getDebates(): Observable<any> {
    return this.http.get(`${environment.url}/debate/all`);
  }

  public getDebate(id: string): Observable<any> {
    return this.http.get(`${environment.url}/debate/${id}`);
  }
}
