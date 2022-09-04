import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Notyf } from 'notyf';
import { Observable } from 'rxjs';
import { Patient } from '../_models/patient';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-bookanappointment',
  templateUrl: './bookanappointment.component.html',
  styleUrls: ['./bookanappointment.component.css']
})
export class BookanappointmentComponent implements OnInit {
  model: any = {}
  loggedIn: boolean = false;//should remove the bookappoin button
  currentUser$: Observable<Patient> = new Observable<Patient>();
  notyf = new Notyf();

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    // this.currentUser$ = this.accountService.currentUser$;
  }

  login(){
    console.log(this.model);
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      let patientName = (this.model.email).split('@')[0];

      this.notyf.success(`Welcome ${patientName}`);
      this.router.navigateByUrl('bookanappointment/' + patientName);
    }, error => {
      console.log(error);
      this.notyf.error(error.error);
    })
  }

  logout(){
    this.loggedIn = false;
    this.router.navigateByUrl('/');
  }

  // setCurrentUser(){
  //   const user: any = JSON.parse(localStorage.getItem('user'));
  //   this.accountService.setCurrentUser(user);
  // }


}
