import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MemberService } from '../../../services/member.service';
import { HttpService } from '../../../services/core/http.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-member-form',
  templateUrl: './member-form.component.html',
  styleUrls: ['./member-form.component.css']
})
export class MemberFormComponent implements OnInit {

  member: any = {};
  memberImgUrl: any;
  isEditForm = false;
  message = '';
  @ViewChild('fileInput') fileInput: ElementRef;
  constructor(private httpService: HttpService,
    private activatedRoute: ActivatedRoute,
    private memberService: MemberService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      let memberId = params['id'];
      if (memberId) {
        this.isEditForm = true;
        this.member.id = memberId;
        this.memberService.get(memberId).subscribe((data): any => {
          this.member = data;
          this.memberImgUrl = data.imageUrl;
        })
      }
    });
    if (!this.member.joiningDate) {
      this.member.joiningDate = new Date();
    }
  }

  saveMember() {
    let files = this.fileInput.nativeElement;
    const frmData: FormData = new FormData();
    if (files.files.length > 0) {
      frmData.append("image", files.files[0]);
    }

    frmData.append("name", this.member.name);
    frmData.append("mobile", this.member.mobile);
    frmData.append("address", this.member.address);
    frmData.append("imageUrl", this.member.imageUrl);
    if (!this.isEditForm) {
      this.memberService.add(frmData).subscribe((data) => {
        this.isEditForm = true;
        this.member = data;
        this.message = 'Member added!';
      });
    } else {
      frmData.append("id", this.member.id);
      this.memberService.update(this.member.id, frmData).subscribe(data => {
        this.member = data;
        this.message = 'Member updated!'
      })
    }
  }

  setImagePreview(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.onload = (e: any) => {
        this.memberImgUrl = e.target.result;
      }
      reader.readAsDataURL(event.target.files[0]);
    }
  }
}