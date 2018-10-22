import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../services/core/http.service';
import { MemberService } from '../../../services/member.service';
import { Router } from '@angular/router';

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
  constructor(private memberService: MemberService,
              private router: Router) {
    this.userList = [];
  }

  ngOnInit() {
    this.memberService.getAll();
  }

  searchNow() {
    if(!this.search) {
      return;
    }
    this.isSearchButtonClicked = true;
    this._userList = this.memberService.allMembers;
    this.memberService.allMembers = this.userList.filter(u => u.mobile == this.search);
  }

  clearSearch() {
    this.search = '';
    this.memberService.allMembers = this._userList;
    this.isSearchButtonClicked = false;
  }

  gotoAddPage() {
    this.router.navigateByUrl("members/form");
  }
}
