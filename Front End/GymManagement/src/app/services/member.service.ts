import { Injectable } from '@angular/core';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  allMembers: any;
  constructor(private httpService: HttpService) { }

  getAll(isArchive = false) {
    let api = `/member`;
    if (isArchive) {
      api = `/member/archive`
    }
    return this.httpService.get(api).subscribe(data => {
      this.allMembers = data;
    })
  }

  add(member) {
    return this.httpService.postData(`/member`, member);
  }

  update(id, member) {
    return this.httpService.putData(`/member/${id}`, member);
  }

  get(id) {
    return this.httpService.get(`/member/${id}`);
  }

  unsubscribe(id) {
    return this.httpService.post(`/member/${id}/unsubscribe`, {});
  }

  rejoin(id) {
    return this.httpService.post(`/member/${id}/rejoin`, {});
  }
}
