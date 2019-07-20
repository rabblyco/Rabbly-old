import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from "../../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DebateService {

  constructor(public http: HttpClient) { }

  public getDebates() {
    return this.http.get(`${environment.url}/debate/all`,{
      headers: {
        'Authorization': `Bearer ${localStorage.getItem("token")}`
      }
    })
  }
}
