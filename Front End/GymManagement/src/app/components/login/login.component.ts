import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/core/auth.service';
import { HttpService } from '../../services/core/http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: any = {};
  loginMessage: any;
  constructor(private httpService: HttpService,
    private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem('token')) {
      this.router.navigateByUrl('dashboard');
    }
  }

  onLoggedin() {
    console.log(this.user);
    this.httpService.login(this.user).then((data) => {
      if (data) {
      } else {
        this.loginMessage = 'Failed to login';
      }
    });
  }
}
