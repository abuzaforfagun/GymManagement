import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams, HttpHeaders, HttpRequest, HttpEventType } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable()
export class HttpService {

  // apiRoot = 'http://speed-gym.azurewebsites.net/api';

  apiRoot = 'http://localhost:50187/api';
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
    return this.http.get(`${this.apiRoot}${url}`, this.getHttpOptions())
      .map(res => res)
      .catch((err) => {
        throw this.handleError(err);
      });
  }

  public post(url, params, isFormdate = false) {
    return this.http.post(`${this.apiRoot}${url}`, params, this.getHttpOptions())
      .map(res => res)
      .catch((err) => {
        throw this.handleError(err);
      });
  }

  public postData(url, params) {
    return this.http.post(`${this.apiRoot}${url}`, params, this.getHttpOptions())
      .catch((err) => {
        throw this.handleError(err);
      });
  }

  public putData(url, params) {
    return this.http.put(`${this.apiRoot}${url}`, params, this.getHttpOptions())
      .catch((err) => {
        throw this.handleError(err);
      });
  }


  login(user): Promise<any> {

    return new Promise((resolve) => {
      this.http.post(`${this.apiRoot}/auth/login`, user)
        .subscribe(data => {
          this.authService.authenticateUser(data);
          resolve(true);
        }, err => resolve(false));
    });
  }


  private getHttpOptions() {
    return {
      headers: new HttpHeaders({
        // 'Content-Type': 'application/json',
        'Authorization': `bearer ${this.authService.getToken()}`
      })
    };
  }

}
