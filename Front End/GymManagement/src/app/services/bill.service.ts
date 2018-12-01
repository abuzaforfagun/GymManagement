import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  constructor(private httpService: HttpService) { }

  pay(memberId, bill) {
    return this.httpService.post(`/member/${memberId}/bill`, bill);
  }
}