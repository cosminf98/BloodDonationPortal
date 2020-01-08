import { Component, OnInit } from '@angular/core';
import {element} from "protractor";
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {ReactiveFormsModule, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
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
        email    : new FormControl(),
        password    : new FormControl(),
      });
}

  onClick(){
  document.getElementById("results").innerText = "Done";
  }
//
  onSubmit() {

    // const formData = new FormData();
    // formData.append('FirstName', this.uploadForm.get('first-name').value);
    
    // this.httpClient.post<any>(this.SERVER_URL, formData).subscribe(
    //   (res) => console.log(res),
    //   (err) => console.log(err)
    // );
    // let httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
    // httpHeaders.append('Accept', 'application/json');
    // let  options = {
    //   headers : httpHeaders,
    //   responseType : "application/json"
    // }
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    };  
// 
    //  const json = JSON.stringify(this.uploadForm.valid);
    //  const jsonObj =JSON.parse(json)
    //  console.log(jsonReq);

    const json = JSON.stringify({
      "UserName" : this.uploadForm.value.username,
      "Email" : this.uploadForm.value.email,
      "FirstName" : this.uploadForm.value.firstname,
      "LastName" : this.uploadForm.value.lastname,
      "Gender" : this.uploadForm.value.gender,
      "DateOfBirth" : this.uploadForm.value.dateOfBirth,
      "BloodType" : this.uploadForm.value.bloodType,
      "City" : this.uploadForm.value.city,
      "Password" : this.uploadForm.value.password
    });
     
    this.httpClient.post(this.SERVER_URL,json,httpOptions)
      .subscribe(
        (data:any) => {
          console.log(data);
        });
        console.log('this');
        
    console.log(json);
  }
}
