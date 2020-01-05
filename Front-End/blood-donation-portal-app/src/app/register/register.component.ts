import { Component, OnInit } from '@angular/core';
import {element} from "protractor";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onClick(){
  document.getElementById("results").innerText = "Done";
  }
}
