import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-login-d',
  templateUrl: './login-d.component.html',
  styleUrls: ['./login-d.component.css']
})
export class LoginDComponent implements OnInit {
  SERVER_URL = "https://localhost:44302/api/donoraccounts/login";
  loginForm: FormGroup;
  lastToken: any;
  lastUserID: any;
  

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private notifierService: NotifierService) { }


  ngOnInit() {
    this.loginForm = new FormGroup({
        email    : new FormControl(),
        password    : new FormControl(),
      });
}

onSubmit() {
  let httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };  

  this.lastToken = localStorage.getItem('donor-token');
  this.lastUserID = localStorage.getItem('donor-id');

    const json = JSON.stringify({
      "Email" : this.loginForm.value.email,
      "Password" : this.loginForm.value.password
    });
     
    this.httpClient.post(this.SERVER_URL,json,httpOptions)
      .subscribe(
        (data:any) => {
          console.log(data);
          if(this.lastUserID != data.id){
            this.notifierService.notify("success", "You are logged in!");
            localStorage.setItem('donor-id',data.id);
          }else{
            this.notifierService.notify("error", "You are already logged in!");
          }
          localStorage.setItem('donor-token',data.token);
          localStorage.setItem('user', 'donor');
          localStorage.setItem('login', 'true');
          window.location.replace("http://localhost:4200");
        });
        
    console.log(json);
    this.loginForm.reset();
    
}

}
