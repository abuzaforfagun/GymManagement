import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/core/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: any;
  password: any;
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  onLoggedin(){
    this.authService.isAuthenticate = true;
    console.log(`Username: ${this.username}; Password: ${this.password}`)
  }
}
