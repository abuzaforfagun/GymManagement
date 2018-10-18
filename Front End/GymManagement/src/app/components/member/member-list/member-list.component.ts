import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../services/core/http.service';
import { MemberService } from '../../../services/member.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  userList: any;
  constructor(private memberService: MemberService) { 
    this.userList = [];
  }

  ngOnInit() {
    this.memberService.getAll().subscribe(data=>{
      this.userList = data;
    })
  }

}
