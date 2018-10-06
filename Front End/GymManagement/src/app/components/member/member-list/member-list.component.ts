import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  userList: any[];
  constructor() { 
    this.userList =[1,2,3];
  }

  ngOnInit() {
  }

}
