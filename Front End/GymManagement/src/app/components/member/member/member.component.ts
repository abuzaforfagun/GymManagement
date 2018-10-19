import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {

  @Input() data: any;
  constructor(private route: Router) { }

  ngOnInit() {
  }

  payNow(member) {
    console.log(member)
    this.route.navigateByUrl(`/payment/${member.id}`);
  }
}
