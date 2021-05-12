import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Member } from './member';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = 'https://localhost:44302/api/Users/Members';
  httpOptions = {
    headers: new HttpHeaders({
      Authorization: `Bearer ${JSON.parse(localStorage.getItem('user') || '{}').token}`
    })
  };

  constructor(private http: HttpClient) { }

  getMembers(){
    return this.http.get<Member[]>(this.baseUrl, this.httpOptions);
  }

  getMember(id: number){
    return this.http.get<Member>(`this.baseUrl/${id}`, this.httpOptions);
  }
}
