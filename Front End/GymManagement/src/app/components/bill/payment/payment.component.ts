import { Component, OnInit } from '@angular/core';
import { MemberService } from '../../../services/member.service';
import { ActivatedRoute } from '@angular/router';
import { BillService } from '../../../services/bill.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  member: any;
  billingDate: any;
  billingAmount: number;
  isBillingComplete: boolean;
  constructor(private activeRoute: ActivatedRoute,
              private memberService: MemberService,
              private billService: BillService) { }

  ngOnInit() {
    const params = this.activeRoute.snapshot.params;
    console.log(params);
    this.memberService.get(params.id).subscribe(data => {
      this.member = data;
    })
  }

  payNow() {
    let bill;
    bill = {
      date: this.billingDate,
      amount: this.billingAmount
    }
    console.log(this.member);
    this.billService.pay(this.member.id, bill).subscribe(data=>{
      this.billingDate = '';
      this.billingAmount = 0;
      this.isBillingComplete = true;
      bill.updateDate = new Date();
      this.member.bills.push(bill);
    })
  }
}
