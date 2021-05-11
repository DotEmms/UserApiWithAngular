import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:44302/api/Account';
  currentUser?: User;
  // httpOptions = {
  //   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  // };  
  constructor(private http: HttpClient) { }

  login(model: any): Observable<any>{
    let url = `${this.baseUrl}/login`;

    return this.http.post( url , model )
    .pipe(
      map((response: any) => 
        { const user = response; 
          if(user)
          {
            localStorage.setItem('user', JSON.stringify(user));
            this.setCurrentUser(user);
          }
        })
      );
  }

  setCurrentUser(user: User){
    this.currentUser = user;
  }

  // getCurrentUser(): User{
  //   if(this.currentUser){
  //     return this.currentUser;
  //   }
  // }

  logout(){
    localStorage.removeItem('user');
    this.currentUser = undefined;
  }

}
