import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  SERVER_URL = "https://localhost:44302/api/donoraccounts/logout";

  constructor(private httpClient: HttpClient,private notifierService: NotifierService) { }

  ngOnInit() {
  }

  onClick(){
      localStorage.setItem('donor-id', "");
      localStorage.setItem('donor-token', "");
      localStorage.setItem('hospital-id', "");
      localStorage.setItem('hospital-token', "");
      localStorage.setItem('user', "");
      localStorage.setItem('login', 'false');
      this.notifierService.notify("success", "You are logged out!");
      window.location.replace("http://localhost:4200");

  }

}
