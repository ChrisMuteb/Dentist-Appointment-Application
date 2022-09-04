import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Doctor } from '../_models/doctor';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-appointmentform',
  templateUrl: './appointmentform.component.html',
  styleUrls: ['./appointmentform.component.css']
})
export class AppointmentformComponent implements OnInit {
  // baseUrl = 'https://localhost:5001/api/';
  doctors: Doctor[];

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.loadDoctors();
  }

  loadDoctors(){
    this.memberService.getDoctors().subscribe(docts => {
      this.doctors = docts;
    })
  }

}
