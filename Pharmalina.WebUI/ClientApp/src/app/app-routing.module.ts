import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationComponent } from './auth/login/authentication.component';
import { from } from 'rxjs';

const routes: Routes = [
  { path: 'login', component: AuthenticationComponent },
  ];

export const RoutingConfig = RouterModule.forRoot(routes);

  @NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
