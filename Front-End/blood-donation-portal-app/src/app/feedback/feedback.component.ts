import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  SERVER_URL = "https://localhost:44355/api/Feedbacks";
  feedbackForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private notifierService: NotifierService) { }

  ngOnInit() {
    this.feedbackForm = new FormGroup({
      email    : new FormControl(),
      message    : new FormControl()
    });
  }

  onSubmit() {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    };  
  
      const json = JSON.stringify({
        "Email" : this.feedbackForm.value.email,
        "Message" : this.feedbackForm.value.message
      });
       
      this.httpClient.post(this.SERVER_URL,json,httpOptions)
        .subscribe(
          (data:any) => {
            console.log(data)
            this.notifierService.notify("success", "You sent feedback!");
            window.location.replace("http://localhost:4200");
          });
          
      console.log(json);
      this.feedbackForm.reset();
  }

}
