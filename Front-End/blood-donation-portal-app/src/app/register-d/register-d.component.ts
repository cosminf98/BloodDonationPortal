import { Component, OnInit } from '@angular/core';
import {element} from "protractor";
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-register-d',
  templateUrl: './register-d.component.html',
  styleUrls: ['./register-d.component.css']
})
export class RegisterDComponent implements OnInit {
  SERVER_URL = "https://localhost:44302/api/donoraccounts/register";
  uploadForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private notifierService: NotifierService) { }

  ngOnInit() {
    this.uploadForm = new FormGroup({
        username    : new FormControl(),
        firstName    : new FormControl(),
        lastName    : new FormControl(),
        gender    : new FormControl(),
        dateOfBirth    : new FormControl(),
        bloodType    : new FormControl(),
        city    : new FormControl(),
        county    : new FormControl(),
        email    : new FormControl(),
        password    : new FormControl(),
        confirmPassword : new FormControl()
      });
}

//
  onSubmit() {

    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    };  
    if(this.uploadForm.value.password == this.uploadForm.value.confirmPassword){
      const json = JSON.stringify({
        "UserName" : this.uploadForm.value.username,
        "Email" : this.uploadForm.value.email,
        "FirstName" : this.uploadForm.value.firstName,
        "LastName" : this.uploadForm.value.lastName,
        "Gender" : this.uploadForm.value.gender,
        "DateOfBirth" : this.uploadForm.value.dateOfBirth,
        "BloodType" : this.uploadForm.value.bloodType,
        "City" : this.uploadForm.value.city,
        "County" : this.uploadForm.value.county,
        "Password" : this.uploadForm.value.password
      });
      
      this.httpClient.post(this.SERVER_URL,json,httpOptions)
        .subscribe(
          (data:any) => {
            console.log(data);
            this.notifierService.notify("success", "You are registered!");
            window.location.replace("http://localhost:4200/login/login-d");
          });
          
      console.log(json);
      this.uploadForm.reset();
    }
    else{
      this.notifierService.notify("error", "Password and confirm password are not the same!");
    }

  }
}
