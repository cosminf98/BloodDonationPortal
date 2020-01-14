import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  SERVER_URL: any;
  id: any;
  auth: any;
  user: any;
  publicNotifications: any;
  httpOptions: { headers: HttpHeaders; };

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.session();
    document.getElementById("notifications").style.visibility = "hidden";
    document.getElementById("hidden").style.visibility = "hidden";
    document.getElementById("logo").style.visibility = "visible";

    if(localStorage.getItem('login') == 'true' && localStorage.getItem('user') == 'donor'){
      this.id = localStorage.getItem('donor-id');
      
      document.getElementById("notifications").style.visibility = "visible";
      document.getElementById("hidden").style.visibility = "visible";
      document.getElementById("logo").style.visibility = "hidden";

      this.SERVER_URL = "https://localhost:44302/api/Donors/" + this.id ;
      this.auth = "Bearer " + localStorage.getItem('donor-token');
      this.httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json',
        'Authorization': this.auth})
      };

      this.httpClient.get(this.SERVER_URL,this.httpOptions).subscribe((response)=>{
        console.log(response);
        this.user = response;
        this.getPublicNotifications();
        this.getPrivateNotifications();
      });

    }

  }

  getPublicNotifications(){
    this.SERVER_URL = "https://localhost:44303/api/PublicNotifications/" +  this.user.county + "/" + this.user.city;
    
    this.httpClient.get(this.SERVER_URL,this.httpOptions).subscribe((response)=>{
      console.log(response);
      this.publicNotifications = response;
    });
  }

  getPrivateNotifications(){
    this.SERVER_URL = "https://localhost:44303/api/PrivateNotifications/" + this.user.email ;
    
    this.httpClient.get(this.SERVER_URL,this.httpOptions).subscribe((response)=>{
      console.log(response);
    });
  }

  session(){
    
    if(localStorage.getItem('login') == 'true'){
      
      
      document.getElementById("logout").style.visibility = "visible";
      document.getElementById("login").style.visibility = "hidden";
      document.getElementById("register").style.visibility = "hidden";

      if(localStorage.getItem('user') == 'hospital'){
        document.getElementById("add").style.visibility = "visible";
        document.getElementById("account").style.visibility = "hidden";
        document.getElementById("message").style.visibility = "hidden";
        document.getElementById("hospitals-nearby").style.visibility = "hidden";
      }

      if(localStorage.getItem('user') == 'donor'){
        document.getElementById("add").style.visibility = "hidden";
        document.getElementById("account").style.visibility = "visible";
        document.getElementById("message").style.visibility = "visible";
        document.getElementById("hospitals-nearby").style.visibility = "visible";
      }
      
    }
    else{
      document.getElementById("account").style.visibility = "hidden";
      document.getElementById("add").style.visibility = "hidden";
      document.getElementById("message").style.visibility = "hidden";
      document.getElementById("hospitals-nearby").style.visibility = "hidden";
      document.getElementById("logout").style.visibility = "hidden";
      document.getElementById("login").style.visibility = "visible";
      document.getElementById("register").style.visibility = "visible";
    }
  }
}
