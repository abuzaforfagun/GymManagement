import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MemberService } from '../../../services/member.service';
import { HttpService } from '../../../services/core/http.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-member-form',
  templateUrl: './member-form.component.html',
  styleUrls: ['./member-form.component.css']
})
export class MemberFormComponent implements OnInit {

  member: any = {};
  memberImgUrl: any;
  @ViewChild('fileInput') fileInput: ElementRef;
  constructor(private httpService: HttpService, private http: HttpClient) { }

  ngOnInit() {
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
    this.httpService.postData("http://localhost:50187/api/member/", frmData).subscribe(data=>{

    })
  }

  setImagePreview(event){
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
  
      reader.onload = (e: any) => {
        this.memberImgUrl = e.target.result;
      }
  
      reader.readAsDataURL(event.target.files[0]);
    }
  }
}