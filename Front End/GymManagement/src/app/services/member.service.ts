import { Injectable } from '@angular/core';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  allMembers: any;
  constructor(private httpService: HttpService) { }

  getAll() {
    return this.httpService.get("http://localhost:50187/api/member").subscribe(data => {
      this.allMembers = data;
    })
  }

  get(id) {
    return this.httpService.get(`http://localhost:50187/api/member/${id}`);
  }

  unsubscribe(id) {
    return this.httpService.post(`http://localhost:50187/api/member/${id}`, {});
  }
}
