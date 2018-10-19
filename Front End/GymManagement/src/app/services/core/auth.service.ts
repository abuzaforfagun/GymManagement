import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isAuthenticate = false;
  token: string;
  constructor() { 
    let token = localStorage.getItem('token');
    if(token){
      this.isAuthenticate = true;
    }
  }
  getToken() {
    if(!this.token){
      this.token = localStorage.getItem('token');
    }
    return this.token;
  }

  getStatus() {
    return this.isAuthenticate;
  }
  authenticateUser(data) {
    this.token = data.token;
    localStorage.setItem('token', data.token);
    this.isAuthenticate = true;
  }

  private checkAuthentication(): Promise<any> {
    return new Promise((resolve, reject) => {
      if (!this.token) {
        const tokenFromStorage = localStorage.getItem('token');
        if (tokenFromStorage === null) {
          resolve(false);
        }
        this.token = tokenFromStorage;
      }
      resolve(true);
    });
  }

  clearAuthentication() {
    localStorage.clear();
    this.isAuthenticate = false;
  }
}
