import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable()
export class ActivityService {

  public Activities: Activity[];
  private apiUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
  }

 

  getAllActivities() {
    //return this.http.get<Activity[]>(this.apiUrl + 'api/AcmeWidget').subscribe(result => {
    //  console.log('Results from API', result);
    //  this.Activities = result;
    //}, error => console.error(error));
    return this.http.get(this.apiUrl + 'api/AcmeWidget/getactivities')
      .pipe(
        map((data: any[]) => {
        this.Activities = data;
          return true;
        }));

  }


}


interface Activity {
  ActivityId: number;
  ActivityName: string;
}
