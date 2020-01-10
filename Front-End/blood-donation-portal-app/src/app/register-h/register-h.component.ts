import { Component, OnInit } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register-h',
  templateUrl: './register-h.component.html',
  styleUrls: ['./register-h.component.css']
})
export class RegisterHComponent implements OnInit {

  SERVER_URL = "https://localhost:44301/api/hospitalaccounts/register";
  uploadForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) { }

  ngOnInit() {
    this.uploadForm = new FormGroup({
        username    : new FormControl(),
        name    : new FormControl(),
        city    : new FormControl(),
        county    : new FormControl(),
        address    : new FormControl(),
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
      "Name" : this.uploadForm.value.name,
      "City" : this.uploadForm.value.city,
      "County" : this.uploadForm.value.county,
      "Address" : this.uploadForm.value.address,
      "Password" : this.uploadForm.value.password
    });
     
    this.httpClient.post(this.SERVER_URL,json,httpOptions)
      .subscribe(
        (data:any) => {
          console.log(data);
        });
        
    console.log(json);
    this.uploadForm.reset();
}
}
