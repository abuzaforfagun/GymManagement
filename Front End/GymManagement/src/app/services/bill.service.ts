import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  apiRoot = 'http://speed-gym.azurewebsites.net/api';
  constructor(private httpService: HttpService) { }

  pay(memberId, bill) {
    return this.httpService.post(`${this.apiRoot}/member/${memberId}/bill`, bill);
  }
}