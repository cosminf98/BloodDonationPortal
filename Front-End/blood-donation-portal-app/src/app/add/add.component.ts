import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  addMobileBank(){
    document.getElementById("mobilebank").style.visibility = "visible";
    document.getElementById("donation").style.visibility = "hidden";
    document.getElementById("hide").style.visibility = "hidden";
  }

  addDonation(){
    document.getElementById("mobilebank").style.visibility = "hidden";
    document.getElementById("donation").style.visibility = "visible";
    document.getElementById("hide").style.visibility = "hidden";

  }

}
