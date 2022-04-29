import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from '../models/account';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  private baseUrl = 'http://localhost:38169/api/user/register';
  account: Account=new Account();

  form = new FormGroup({
    email: new FormControl(null, Validators.required),
    pw: new FormControl(null, Validators.required),
    cpw: new FormControl(null, Validators.required),
  })

  constructor(private httpClient: HttpClient, private router: Router) {

  }

  ngOnInit() {
  }

  onRegister() {
    if (this.form.valid) {
      if (this.form.get('pw').value != this.form.get('cpw').value) {
        alert("Passwords don't match!");
      }
      else {
        this.account.email = this.form.get('email').value;
        this.account.password = this.form.get('pw').value;
        this.httpClient.post(this.baseUrl, this.account).subscribe(res => {
          alert("Successfully registered")
          this.router.navigate(['/login'])
        },
         (error) => alert("Email already registered")
        );
      }
    }
  }
}
