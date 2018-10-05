import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private http: HttpClient) { }

  handleError(err) {
    return Observable.throw("Failed to handle the request!");
  }
  public get(url, params) {
    return this.http.get(url, { params: params })
      .map(res => res)
      .catch((err) => {
        throw this.handleError(err);
      });
  }

  public post(url, params, headers) {
    return this.http.post(url, params)
      .map(res => res);
  }

}
