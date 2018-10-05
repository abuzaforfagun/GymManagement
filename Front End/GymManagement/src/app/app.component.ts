import { Component } from '@angular/core';
import { AuthService } from './services/core/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'GymManagement';
  collapedSideBar: boolean;

  constructor(public authService: AuthService) {
    
  }
  receiveCollapsed($event) {
    this.collapedSideBar = $event;
  }
}
