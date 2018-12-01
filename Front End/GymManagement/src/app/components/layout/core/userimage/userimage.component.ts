import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'user-image',
  templateUrl: './userimage.component.html',
  styleUrls: ['./userimage.component.css']
})
export class UserimageComponent implements OnInit {
  @Input() img;
  constructor() { }

  ngOnInit() {
  }

}
