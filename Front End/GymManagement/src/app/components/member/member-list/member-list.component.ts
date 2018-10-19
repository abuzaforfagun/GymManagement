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
  _userList: any;
  search: '';
  isSearchButtonClicked = false;
  constructor(private memberService: MemberService) {
    this.userList = [];
  }

  ngOnInit() {
    this.memberService.getAll().subscribe(data => {
      this.userList = data;
    })
  }

  searchNow() {
    if(!this.search) {
      return;
    }
    this.isSearchButtonClicked = true;
    this._userList = this.userList;
    this.userList = this.userList.filter(u => u.mobile == this.search);
  }

  clearSearch() {
    this.search = '';
    this.userList = this._userList;
    this.isSearchButtonClicked = false;
  }
}
