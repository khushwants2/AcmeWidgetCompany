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
 public userList: any;

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
    const promise = this.registrationService.saveUserRegistration(this.registrationForm.value);
    promise.then((data) => {
      if (data != null && data != undefined) {
        console.log("System returned Messgae: " + JSON.stringify(data));
        this.userList = data;
        this.registrationForm.reset();
        this.showappuserlistdetail = true;
        this.showSuccessAlert = true;
        this.showErrorAlert = false;
        return true;
      }
      else {
        this.showappuserlistdetail = false;
        this.showSuccessAlert = false;
        this.showErrorAlert = true;
        return false;
      }
    },
      (error) => {
        console.log("User registration error: " + JSON.stringify(error));
      });
    //this.registrationForm.reset();
    //this.showappuserlistdetail = this.registrationService.showUserList;
    //this.showSuccessAlert = this.registrationService.showSuccessMessage;
    //this.showErrorAlert = this.registrationService.showErrorMessage;
  }
  hideUserdetail() {
    this.registrationForm.reset();
    this.showappuserlistdetail = false;
  }

}

