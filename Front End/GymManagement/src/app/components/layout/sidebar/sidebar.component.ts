import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  isActive: boolean = false;
  collapsed: boolean = false;
  showMenu: string = '';
  pushRightClass: string = 'push-right';
  @Output() collapsedEvent = new EventEmitter<boolean>();
  constructor() { }

  ngOnInit() {
  }

  
  eventCalled() {
    this.isActive = !this.isActive;
}

addExpandClass(element: any) {
    if (element === this.showMenu) {
        this.showMenu = '0';
    } else {
        this.showMenu = element;
    }
}

toggleCollapsed() {
    this.collapsed = !this.collapsed;
    this.collapsedEvent.emit(this.collapsed);
}

isToggled(): boolean {
    const dom: Element = document.querySelector('body');
    return dom.classList.contains(this.pushRightClass);
}

toggleSidebar() {
    const dom: any = document.querySelector('body');
    dom.classList.toggle(this.pushRightClass);
}

rltAndLtr() {
    const dom: any = document.querySelector('body');
    dom.classList.toggle('rtl');
}

changeLang(language: string) {
    this.translate.use(language);
}

onLoggedout() {
    localStorage.removeItem('isLoggedin');
}
}