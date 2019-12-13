import { OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable()
export class RegistrationService implements OnInit {
  private apiUrl: string;
  public userList: any;
  public list: any[];
  public showUserList: boolean;
  public showSuccessMessage: boolean;
  public showErrorMessage: boolean;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
    this.showUserList = false;
  }


  ngOnInit() { 
  }

  getUserList() {
    return this.userList;
  }

   saveUserRegistration(postData) {
    var sendData: register = postData
    sendData.activityid = Number(sendData.activityid);

    console.log("postdata", sendData);
     this.http.post(
      this.apiUrl + "api/AcmeWidget/saveuserregistration",
      sendData)     
      .subscribe(data => {

        if (data != null && data != undefined) {
          this.userList = data;
          console.log('userlist', this.userList);
          this.showUserList = true;
          this.showSuccessMessage = true;
          this.showErrorMessage = false;
          return true;
        }
        else {
          this.showUserList = false;
          this.showSuccessMessage = false;
          this.showErrorMessage = true;
          return false;
        }
      });;
      
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

