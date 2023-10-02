import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getJourney(origin:string,destination:string): Observable<any> {
    return this.http.get(`api/Journey/GetJourney/${origin}/${destination}`);
  }
}
