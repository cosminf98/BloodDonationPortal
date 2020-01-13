import {Component, OnInit} from'@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  ngOnInit() {
    
      this.session();
    

      document.getElementById("account").style.visibility = "hidden";
      document.getElementById("add").style.visibility = "hidden";
      document.getElementById("message").style.visibility = "hidden";
      document.getElementById("hospitals-nearby").style.visibility = "hidden";
      document.getElementById("logout").style.visibility = "hidden";
      document.getElementById("login").style.visibility = "visible";
      document.getElementById("register").style.visibility = "visible";

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

  title = 'blood-donation-portal-app';
  
}
