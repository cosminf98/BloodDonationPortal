import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-hospitals-nearby',
  templateUrl: './hospitals-nearby.component.html',
  styleUrls: ['./hospitals-nearby.component.css']
})
export class HospitalsNearbyComponent implements OnInit {
  SERVER_URL = "https://localhost:44301/api/Hospitals/Iasi";
  hospitals: any;
  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    let httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJEb25vckVtYWlsIjoibXktZW1haWxAZ21haWwuY29tIiwiSWQiOiI2MWNiN2VkOS05MTAwLTRhOTktYzJjNy0wOGQ3OTUwODFiMzgiLCJleHAiOjE1NzkzNDU5NTEsImlzcyI6IjQ0MzE1IiwiYXVkIjoiNDQzMTUifQ.eAwSPPL8Jz0QTq_EzJHxtg1Tasjklpg1pZqq_wUFb9M'})
  };
    this.httpClient.get(this.SERVER_URL,httpOptions).subscribe((response)=>{
      console.log(response);
      this.hospitals = response;
    });
    
  }

}
