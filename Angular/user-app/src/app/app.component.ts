import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './account.service';
import { Login } from './login';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(private accountService: AccountService) {}
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user : Login = JSON.parse(localStorage.getItem('user') || '{}');
    this.accountService.setCurrentUser(user);
  }
  title = 'user-app';
}
