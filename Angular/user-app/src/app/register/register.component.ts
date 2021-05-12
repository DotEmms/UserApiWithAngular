import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerUser: FormGroup = new FormGroup({
    username: new FormControl(),
    password: new FormControl(),
  })
  
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }


  register(){
    console.log(this.registerUser.value);
  }
}