import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:44302/api/Account';
  // httpOptions = {
  //   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  // };  
  constructor(private http: HttpClient) { }

  login(model: any): Observable<any>{
    let url = `${this.baseUrl}/login`;
    return this.http.post( url , model )
  }

}
