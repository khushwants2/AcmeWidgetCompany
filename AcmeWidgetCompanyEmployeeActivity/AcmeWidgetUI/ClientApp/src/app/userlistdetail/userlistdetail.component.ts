import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../service/registration.service';

@Component({
  selector: 'app-userlistdetail',
  templateUrl: './userlistdetail.component.html',
  styleUrls: ['./userlistdetail.component.css']
})
export class UserlistdetailComponent implements OnInit {
  displayedColumns: string[] = ['FirstName', 'LastName', 'EmailAddress', 'Comments','ActivityName'];
  dataSource = [];
  constructor(private registrationService: RegistrationService ) { }

  ngOnInit() {
    this.dataSource = this.registrationService.getUserList();
  }

}

//FirstName: string,
//  LastName: string,
//    EmailAddress: string,
//      Comments: string,
//        ActivityName: string,
//          ActivityId: number
