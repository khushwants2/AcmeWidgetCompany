import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivityService } from '../service/activity.service';
import { RegistrationService } from '../service/registration.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registrationForm: FormGroup;
  public activities = [];
  public showappuserlistdetail: boolean;
  public showSuccessAlert: boolean;
  public showErrorAlert: boolean;
  

  constructor(private data: ActivityService,
    private registrationService: RegistrationService) {
  }

  ngOnInit(): void {
    this.showappuserlistdetail = false;
    this.data.getAllActivities().subscribe(success => {
      if (success) {        
        this.activities = this.data.Activities;
        console.log('Activities: ', this.activities);
      }
    });    
   

    this.registrationForm = new FormGroup({
      'firstname': new FormControl(null, [Validators.required, Validators.minLength(5)]),
      'lastname': new FormControl(null,[Validators.required, Validators.minLength(5)]),
      'emailaddress': new FormControl(null, [Validators.required, Validators.email]),
      'activityid': new FormControl(null, [Validators.required]),
      'comments': new FormControl(null, [Validators.maxLength(250)]),
    });
  }
  onSubmit() {
    this.showSuccessAlert = false;
    this.showErrorAlert = false;
    this.showappuserlistdetail = false;
    console.log(this.registrationForm.value);
    this.registrationService.saveUserRegistration(this.registrationForm.value);
    this.registrationForm.reset();
    this.showappuserlistdetail = true;//this.registrationService.showUserList;
    this.showSuccessAlert = true;//this.registrationService.showSuccessMessage;
    this.showErrorAlert = this.registrationService.showErrorMessage;
  }
  hideUserdetail() {
    this.registrationForm.reset();
    this.showappuserlistdetail = false;
  }

}

