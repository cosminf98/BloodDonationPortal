import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AccountComponent } from './account/account.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { RegisterHComponent } from './register-h/register-h.component';
import { RegisterDComponent } from './register-d/register-d.component';
import { LoginDComponent } from './login-d/login-d.component';
import { LoginHComponent } from './login-h/login-h.component';
import { HospitalsNearbyComponent } from './hospitals-nearby/hospitals-nearby.component';
import { NotifierModule } from 'angular-notifier';
import { FeedbackComponent } from './feedback/feedback.component';
import { LogoutComponent } from './logout/logout.component';
import { AddComponent } from './add/add.component';
//
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    AccountComponent,
    RegisterHComponent,
    RegisterDComponent,
    LoginDComponent,
    LoginHComponent,
    HospitalsNearbyComponent,
    FeedbackComponent,
    LogoutComponent,
    AddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NotifierModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
