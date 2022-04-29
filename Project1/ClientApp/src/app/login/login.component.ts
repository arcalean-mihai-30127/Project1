import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from '../models/account';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private baseUrl = 'http://localhost:38169/api/user/login';
  account: Account = new Account();


  form = new FormGroup({
    email: new FormControl(null, Validators.required),
    pw: new FormControl(null, Validators.required),
  })

  constructor(private httpClient: HttpClient, private router: Router) {
    
  }

  ngOnInit() {
  }

  onLogin() {
    if (this.form.valid) {
      this.account.email = this.form.get('email').value;
      this.account.password = this.form.get('pw').value;
      this.httpClient.post(this.baseUrl, this.account).subscribe(res => {

        alert("Successfully logged in"),
          localStorage.setItem('token', this.account.email),
          window.location.href = window.location.protocol + '//' + window.location.host + '/home';
         // this.router.navigate(['home'])
      }, error => alert("Wrong credentials!"));
    }
  }
}
