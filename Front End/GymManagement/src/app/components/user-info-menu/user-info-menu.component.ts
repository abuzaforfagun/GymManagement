import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/core/auth.service';

@Component({
    selector: 'user-info-menu',
    templateUrl: './user-info-menu.component.html',
    styleUrls: ['./user-info-menu.component.css']
})
export class UserInfoMenuComponent implements OnInit {

    constructor(private authService: AuthService) { }

    ngOnInit() {
    }

    onLoggedout() {
        this.authService.clearAuthentication();
    }
}
