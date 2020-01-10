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

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'login/login-d', component: LoginDComponent},
  {path: 'login/login-h', component: LoginHComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'register/register-d', component: RegisterDComponent},
  {path: 'register/register-h', component: RegisterHComponent},
  {path: 'account', component: AccountComponent},
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
