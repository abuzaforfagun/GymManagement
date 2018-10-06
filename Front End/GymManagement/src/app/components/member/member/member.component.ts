import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {

  @Input() data: any;
  constructor() { }

  ngOnInit() {
  }

}
