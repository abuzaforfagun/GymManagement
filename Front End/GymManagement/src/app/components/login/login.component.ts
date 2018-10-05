import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: any;
  password: any;
  constructor() { }

  ngOnInit() {
  }

  onLoggedin(){
    console.log(`Username: ${this.username}; Password: ${this.password}`)
  }
}
