import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'userimage',
  templateUrl: './userimage.component.html',
  styleUrls: ['./userimage.component.css']
})
export class UserimageComponent implements OnInit {
  @Input("img") img;
  constructor() { }

  ngOnInit() {
  }

}
