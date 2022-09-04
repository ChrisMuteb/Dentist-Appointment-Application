import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dentist Appointment Application';
  doctors: any;

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.getDoctors();
  }

  getDoctors(){
    this.http.get('https://localhost:5001/api/doctors').subscribe(response => {
      this.doctors = response;
    }, error => {
      console.log(error);
    })
  }
}
