import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginDComponent} from "./login-d/login-d.component";
import {LoginHComponent} from "./login-h/login-h.component";
import {HomeComponent} from "./home/home.component";
import {RegisterComponent} from "./register/register.component";
import {LoginComponent} from "./login/login.component";
import {AccountComponent} from "./account/account.component";
import {RegisterHComponent} from "./register-h/register-h.component";
import {RegisterDComponent} from "./register-d/register-d.component";
import { HospitalsNearbyComponent } from './hospitals-nearby/hospitals-nearby.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { LogoutComponent } from './logout/logout.component';
import { AddComponent } from './add/add.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'logout', component: LogoutComponent},
  {path: 'account', component: AccountComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'feedback', component: FeedbackComponent},
  {path: 'hospitals/nearby', component: HospitalsNearbyComponent},
  {path: 'add', component: AddComponent},
  {path: 'register/register-d', component: RegisterDComponent},
  {path: 'register/register-h', component: RegisterHComponent},
  {path: 'login/login-d', component: LoginDComponent},
  {path: 'login/login-h', component: LoginHComponent},
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
