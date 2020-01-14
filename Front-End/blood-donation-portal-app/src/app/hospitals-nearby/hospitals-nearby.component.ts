import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-hospitals-nearby',
  templateUrl: './hospitals-nearby.component.html',
  styleUrls: ['./hospitals-nearby.component.css']
})
export class HospitalsNearbyComponent implements OnInit {
  SERVER_URL: any;
  hospitals: any;
  mobilebanks: any;
  httpOptions: { headers: HttpHeaders; };
  city:string= "";
  token: any;
  id: any;
  user: any;
  auth: any;

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
      this.searchByCityOrCounty(this.user.city);
      this.getMobileBanks();
    });

    
    

  }

  searchByCityOrCounty(cityOrCounty){
    console.log(cityOrCounty);
    this.SERVER_URL = "https://localhost:44301/api/Hospitals/"+cityOrCounty;
    
    this.httpClient.get(this.SERVER_URL,this.httpOptions).subscribe((response)=>{
      console.log(response);
      this.hospitals = response;
    });
  }

  getMobileBanks(){
    this.SERVER_URL = "https://localhost:44301/api/mobilebloodbanks" ;
    this.httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    };

    this.httpClient.get(this.SERVER_URL,this.httpOptions).subscribe((response)=>{
      console.log(response);
      this.mobilebanks = response;
    });
  }

}
