import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  SERVER_URL: any;
  mobilebankForm: FormGroup;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };
  
  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private notifierService: NotifierService) { }

  ngOnInit() {
    this.mobilebankForm = new FormGroup({
      name    : new FormControl(),
      about    : new FormControl(),
      date    : new FormControl(),
      city    : new FormControl()
    });

    const json = JSON.stringify({
      "Name" : this.mobilebankForm.value.name,
      "About" : this.mobilebankForm.value.about,
      "Date" : this.mobilebankForm.value.date,
      "City" : this.mobilebankForm.value.city
    });

    this.httpClient.post(this.SERVER_URL,json,this.httpOptions)
        .subscribe(
          (data:any) => {
            console.log(data)
              this.notifierService.notify("success", "You added a mobile bank!");
          });
          
      console.log(json);
      this.mobilebankForm.reset();
      
  }

  addMobileBank(){
    document.getElementById("mobilebank").style.visibility = "visible";
    document.getElementById("donation").style.visibility = "hidden";
    document.getElementById("hide").style.visibility = "hidden";

    this.SERVER_URL = "https://localhost:44301/api/mobilebloodbanks";


  }

  addDonation(){
    document.getElementById("mobilebank").style.visibility = "hidden";
    document.getElementById("donation").style.visibility = "visible";
    document.getElementById("hide").style.visibility = "hidden";

  }

}
