import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/core/auth.service';
import { HttpService } from '../../services/core/http.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user = {};
  loginMessage: any;
  constructor(private httpService: HttpService) { }

  ngOnInit() {
  }

  onLoggedin(){
    console.log(this.user);
    this.httpService.login(this.user).then((data) => {
      if (data) {
      } else {
        this.loginMessage = 'Failed to login';
      }
    });
  }
}
