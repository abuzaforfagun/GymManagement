import { Injectable } from '@angular/core';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  allMembers: any;
  constructor(private httpService: HttpService) { }

  getAll(isArchive = false) {
    let api = "http://localhost:50187/api/member";
    if(isArchive){
      api = "http://localhost:50187/api/member/archive"
    }
    return this.httpService.get(api).subscribe(data => {
      this.allMembers = data;
    })
  }

  get(id) {
    return this.httpService.get(`http://localhost:50187/api/member/${id}`);
  }

  unsubscribe(id) {
    return this.httpService.post(`http://localhost:50187/api/member/${id}/unsubscribe`, {});
  }

  rejoin(id) {
    return this.httpService.post(`http://localhost:50187/api/member/${id}/rejoin`, {});
  }

  add(member) {
    console.log(member);
  }
}
