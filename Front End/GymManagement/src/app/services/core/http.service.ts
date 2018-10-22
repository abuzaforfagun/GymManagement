import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams, HttpHeaders, HttpRequest, HttpEventType } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable()
export class HttpService {

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  handleError(err) {
    if (err.status === 401) {
      this.authService.clearAuthentication();
      return Observable.throw("Authentication failed!");
    }

    return Observable.throw("Failed to handle the request!");

  }
  public get(url) {
    return this.http.get(url, this.getHttpOptions())
      .map(res => res)
      .catch((err) => {
        throw this.handleError(err);
      });
  }

  public post(url, params, isFormdate = false) {
    return this.http.post(url, params, this.getHttpOptions(isFormdate))
      .map(res => res);
  }
  
  public postData(url, params) {
    return this.http.post(url, params);
  }
  

  login(user): Promise<any> {
    
    return new Promise((resolve) => {
      this.http.post('http://localhost:50187/api/auth/login', user)
        .subscribe(data => {
          this.authService.authenticateUser(data);
          resolve(true);
        }, err => resolve(false));
    });
  }


  private getHttpOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `bearer ${this.authService.getToken()}`
      })
    };
  }

}
