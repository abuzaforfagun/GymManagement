import { Injectable } from '@angular/core';
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
