import { OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable()
export class RegistrationService implements OnInit {
  private apiUrl: string;


  public showSuccessMessage: boolean;
  public showErrorMessage: boolean;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
    
  }


  ngOnInit() { 
  }

  

   saveUserRegistration(postData) {
    var sendData: register = postData
    sendData.activityid = Number(sendData.activityid);

    console.log("postdata", sendData);
     const promise = this.http.post(
       this.apiUrl + "api/AcmeWidget/saveuserregistration",
       sendData).toPromise();
     return promise;
      
  }

}
interface register {
  firstname: string,
  lastname: string,
  emailaddress: string,
  comments: string,
  activityid: number
}

interface UserList {
  FirstName: string,
  LastName: string,
  EmailAddress: string,
  Comments: string,
  ActivityName: string,
  ActivityId: number
}

