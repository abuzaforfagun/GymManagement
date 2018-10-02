import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'GymManagement';
  collapedSideBar: boolean;

  receiveCollapsed($event) {
    this.collapedSideBar = $event;
  }
}
