import { Injectable } from '@angular/core';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(private httpService: HttpService) { }

  getAll(){
    return this.httpService.get("http://localhost:50187/api/member");
  }

  get(id){
    return this.httpService.get(`http://localhost:50187/api/member/${id}`);
  }
}
