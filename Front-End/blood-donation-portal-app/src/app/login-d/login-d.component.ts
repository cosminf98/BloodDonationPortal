import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login-d',
  templateUrl: './login-d.component.html',
  styleUrls: ['./login-d.component.css']
})
export class LoginDComponent implements OnInit {
  SERVER_URL = "https://localhost:44302/api/donoraccounts/login";
  loginForm: FormGroup;
  token: any;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) { }


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

  
  const json = JSON.stringify({
    "Email" : this.loginForm.value.email,
    "Password" : this.loginForm.value.password
  });
   
  this.httpClient.post(this.SERVER_URL,json,httpOptions)
    .subscribe(
      (data:any) => {
        console.log(data);
        this.token = data.token;
      });
      
  console.log(json);
  console.log(this.token);
  this.loginForm.reset();
}
}
