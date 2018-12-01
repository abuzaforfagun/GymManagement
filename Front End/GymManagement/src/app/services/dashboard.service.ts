import { Injectable } from '@angular/core';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  unpaidBills: any;
  unpaidBillForOneMonth: any;
  unpaidBillForMoreThanOneMonth: any;
  constructor(private httpService: HttpService) { }

  getUnpaidBills() {
    this.httpService.get(`/dashboard/unpaid`).subscribe(data => {
      this.unpaidBills = data;
      this.unpaidBillForOneMonth = this.unpaidBills.filter(bill => bill.unpaidBills.length === 1);
      this.unpaidBillForMoreThanOneMonth = this.unpaidBills.filter(bill => bill.unpaidBills.length > 1);
      console.log(this.unpaidBillForOneMonth);
    });
  }

}
