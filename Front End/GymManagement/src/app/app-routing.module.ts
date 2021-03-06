import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MemberListComponent } from './components/member/member-list/member-list.component';
import { PaymentComponent } from './components/bill/payment/payment.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MemberFormComponent } from './components/member/member-form/member-form.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'members', component: MemberListComponent },
    { path: 'members/form', component: MemberFormComponent },
    { path: 'members/form/:id', component: MemberFormComponent },
    { path: 'members/:action', component: MemberListComponent },
    { path: 'payment/:id', component: PaymentComponent },
    { path: 'dashboard', component: DashboardComponent }
];
@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes,
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }
