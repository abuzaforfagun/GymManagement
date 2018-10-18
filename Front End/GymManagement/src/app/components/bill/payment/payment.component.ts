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
    const bill = {
      date: this.billingDate,
      amount: this.billingAmount
    }
    this.billService.pay(this.member.id, bill).subscribe(data=>{
      this.billingDate = '';
      this.billingAmount = 0;
      this.isBillingComplete = true;
      console.log(this.isBillingComplete)
    })
  }
}
