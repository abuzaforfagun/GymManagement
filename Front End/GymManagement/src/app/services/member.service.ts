import { Injectable } from '@angular/core';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  apiRoot = 'http://speed-gym.azurewebsites.net/api';
  allMembers: any;
  constructor(private httpService: HttpService) { }

  getAll(isArchive = false) {
    let api = `${this.apiRoot}/member`;
    if(isArchive){
      api = `${this.apiRoot}/member/archive`
    }
    return this.httpService.get(api).subscribe(data => {
      this.allMembers = data;
    })
  }

  add(member) {
    return this.httpService.postData(`${this.apiRoot}/member`, member);
  }

  update(id, member) {
    return this.httpService.putData(`${this.apiRoot}/member/${id}`, member);
  }

  get(id) {
    return this.httpService.get(`${this.apiRoot}/member/${id}`);
  }

  unsubscribe(id) {
    return this.httpService.post(`${this.apiRoot}/member/${id}/unsubscribe`, {});
  }

  rejoin(id) {
    return this.httpService.post(`${this.apiRoot}/member/${id}/rejoin`, {});
  }
}
