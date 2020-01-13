import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.session();

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
