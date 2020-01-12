import { Component, OnInit } from '@angular/core';
import {element} from "protractor";
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {ReactiveFormsModule, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register-d',
  templateUrl: './register-d.component.html',
  styleUrls: ['./register-d.component.css']
})
export class RegisterDComponent implements OnInit {
  SERVER_URL = "https://localhost:44302/api/donoraccounts/register";
  uploadForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) { }

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
      });
}

//
  onSubmit() {

    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    };  

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
        });
        console.log('this');
        
    console.log(json);
    this.uploadForm.reset();
  }
}
