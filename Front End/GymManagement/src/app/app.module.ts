import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './components/login/login.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { SidebarComponent } from './components/layout/sidebar/sidebar.component';
import { MemberListComponent } from './components/member/member-list/member-list.component';
import { MemberComponent } from './components/member/member/member.component';
import { HttpService } from './services/core/http.service';
import { MemberService } from './services/member.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AuthService } from './services/core/auth.service';
import { UserInfoMenuComponent } from './components/user-info-menu/user-info-menu.component';
import { PaymentComponent } from './components/bill/payment/payment.component';
import { UserimageComponent } from './components/layout/core/userimage/userimage.component';
import { MemberInfoComponent } from './components/member/member/member-info/member-info.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MemberFormComponent } from './components/member/member-form/member-form.component';
import { NgDatepickerModule } from 'ng2-datepicker';
import { DeprecatedDatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    SidebarComponent,
    MemberListComponent,
    MemberComponent,
    UserInfoMenuComponent,
    PaymentComponent,
    UserimageComponent,
    MemberInfoComponent,
    DashboardComponent,
    MemberFormComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgDatepickerModule,
    NgbModule
  ],
  providers: [MemberService, HttpService, AuthService, DeprecatedDatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
