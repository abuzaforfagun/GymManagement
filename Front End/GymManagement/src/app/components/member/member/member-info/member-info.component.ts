import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'member-info',
  templateUrl: './member-info.component.html',
  styleUrls: ['./member-info.component.css']
})
export class MemberInfoComponent implements OnInit {
  @Input() data;
  @Input() isDisplayLastPaymentDate = true;
  constructor() { }

  ngOnInit() {
  }

}
