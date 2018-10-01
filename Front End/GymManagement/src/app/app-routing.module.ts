import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  // { path: 'stories', component: StoriesComponent },
  // { path: 'stories/form', component: StoryFormComponent },
  // { path: 'stories/form/:id', component: StoryFormComponent },
  // { path: 'login', component: LoginComponent },
  // { path: 'register', component: RegisterComponent },
  // { path: '', redirectTo: '/stories', pathMatch: 'full' },
  // { path: '**', component: PageNotFoundComponent }
];
@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
  )
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule { }
