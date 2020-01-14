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
  donationForm: FormGroup;
  callToActionForm: FormGroup;
  auth = "Bearer " + localStorage.getItem('hospital-token');

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Authorization': this.auth})
  };

  
  
  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private notifierService: NotifierService) { }

  ngOnInit() {
    this.mobilebankForm = new FormGroup({
      name    : new FormControl(),
      about    : new FormControl(),
      date    : new FormControl(),
      city    : new FormControl()
    });

    this.donationForm = new FormGroup({
    });

    this.callToActionForm = new FormGroup({
      bloodtypeneeded : new FormControl(),
      hospitalcenter : new FormControl(),
      county : new FormControl()
    });

    document.getElementById("mobilebank").style.visibility = "hidden";
    document.getElementById("donation").style.visibility = "hidden";
    document.getElementById("callToAction").style.visibility = "hidden";
    document.getElementById("hide").style.visibility = "visible";
    
      
  }

  addMobileBank(){
    document.getElementById("mobilebank").style.visibility = "visible";
    document.getElementById("donation").style.visibility = "hidden";
    document.getElementById("callToAction").style.visibility = "hidden";
    document.getElementById("hide").style.visibility = "hidden";
  }

  addDonation(){
    document.getElementById("mobilebank").style.visibility = "hidden";
    document.getElementById("donation").style.visibility = "visible";
    document.getElementById("callToAction").style.visibility = "hidden";
    document.getElementById("hide").style.visibility = "hidden";
  }

  addCallToAction(){
    document.getElementById("mobilebank").style.visibility = "hidden";
    document.getElementById("donation").style.visibility = "hidden";
    document.getElementById("callToAction").style.visibility = "visible";
    document.getElementById("hide").style.visibility = "hidden";
  }

  onSubmitMobileBank(){
    this.SERVER_URL = "https://localhost:44301/api/mobilebloodbanks";

    const datesAndLocations =[{
      "Date" : this.mobilebankForm.value.date,
      "City" : this.mobilebankForm.value.city
    }];

    const json = JSON.stringify({
      "Name" : this.mobilebankForm.value.name,
      "About" : this.mobilebankForm.value.about,
      "DatesAndLocations" : datesAndLocations
    });

    console.log(json);
    this.httpClient.post(this.SERVER_URL,json,this.httpOptions)
        .subscribe(
          (data:any) => {
            // if(data.status == 401){
            //   this.notifierService.notify("error", "You should log in first!");
            //   window.location.replace("http://localhost:4200/login/login-h");
            // }
            console.log(data)
            this.notifierService.notify("success", "You added a mobile bank!");
            window.location.replace("http://localhost:4200/add");
          });
          
      console.log(json);
      this.mobilebankForm.reset();
  }

  onSubmitCallToAction(){
    this.SERVER_URL = "https://localhost:44302/api/donors/calltoaction";

    const json = JSON.stringify({
      "County" : this.callToActionForm.value.county,
      "BloodTypeNeeded" : this.callToActionForm.value.bloodtypeneeded,
      "HospitalCenter" : this.callToActionForm.value.hospitalcenter
    });

    console.log(json);
    this.httpClient.post(this.SERVER_URL,json,this.httpOptions)
        .subscribe(
          (data:any) => {
            // if(data.status == 401){
            //   this.notifierService.notify("error", "You should log in first!");
            //   window.location.replace("http://localhost:4200/login/login-h");
            // }
            console.log(data)
            this.notifierService.notify("success", "You added a call to action!");
            window.location.replace("http://localhost:4200/add");
          });
          
      console.log(json);
      this.callToActionForm.reset();

  }

}
