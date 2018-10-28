import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MemberService } from '../../../services/member.service';

@Component({
  selector: 'member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {

  @Input() data: any;
  @Input() isArchive = false;
  constructor(private route: Router,
    private memberService: MemberService) { }

  ngOnInit() {
  }

  payNow(member) {
    console.log(member)
    this.route.navigateByUrl(`/payment/${member.id}`);
  }

  delete(member) {
    if (confirm(`Delete ${member.name}?`)) {
      this.memberService.unsubscribe(member.id).subscribe(data => {
        this.memberService.allMembers = this.memberService.allMembers.filter(m=>m.id !== member.id);
      })
    }
  }

  rejoin(member) {
    if (confirm(`Rejoin ${member.name}?`)) {
      this.memberService.rejoin(member.id).subscribe(()=>{
        this.memberService.allMembers = this.memberService.allMembers.filter(m=>m.id !== member.id);
      });
    }
    
  }

  editMember(member) {
    this.route.navigateByUrl(`members/form/${member.id}`);
  }
}
