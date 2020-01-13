import { Component, OnInit } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  SERVER_URL: any;
  id: any;
  auth: any;
  user: any;
  httpOptions: { headers: HttpHeaders; };
  firstName:string = "";
  lastName:string = "";
  date:string = "";
  bloodType:string = "";
  gender:string = "";
  email:string = "";
  password:string = "";
  address:string = "";
  city:string = "";
  county:string = "";
  donations: any;

  
  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    
    
      this.id = localStorage.getItem('donor-id');
      this.SERVER_URL = "https://localhost:44302/api/Donors/" + this.id ;
      this.auth = "Bearer " + localStorage.getItem('donor-token');
      this.httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json',
        'Authorization': this.auth})
      };

      this.httpClient.get(this.SERVER_URL,this.httpOptions).subscribe((response)=>{
        console.log(response);
        this.user = response;
        this.firstName = this.user.firstName;
        this.lastName = this.user.lastName;
        this.date = this.user.dateOfBirth;
        this.bloodType = this.user.bloodType;
        this.gender = this.user.gender;
        this.email = this.user.email;
        this.city = this.user.city;
        this.county = this.user.county;
      });

      this.SERVER_URL = "https://localhost:44302/api/Donors/gethistory/" + this.id ;

      this.httpClient.get(this.SERVER_URL,this.httpOptions).subscribe((response)=>{
        console.log(response);
        this.donations = response;
      });
    }
    
}
