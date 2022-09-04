import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Notyf } from 'notyf';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-newpatient',
  templateUrl: './newpatient.component.html',
  styleUrls: ['./newpatient.component.css']
})
export class NewpatientComponent implements OnInit {
  registerMode = false;
  model: any = {};
  notyfSignup = new Notyf();


  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  register(){
    console.log(this.model);
    this.accountService.register(this.model).subscribe(Response => {
      console.log(Response);
      this.notyfSignup.success("You've successfully signed up");
      this.router.navigateByUrl('bookanappointment/123');
      this.cancel();
    }, error => {
      console.log(error);
      this.notyfSignup.error(error.error);
    })
  }

  cancel(){
    console.log('cancel');
  }

}
