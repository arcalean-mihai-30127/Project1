import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  isLoggedIn: boolean = false;

  constructor() {

  }

  ngOnInit() {
    this.loggedIn();
  }

  loggedIn() {
    if (localStorage.getItem('token')) {
      this.isLoggedIn = true;
    }
    else {
      this.isLoggedIn = false;
    }
  }

  refreshLogin() {
    this.loggedIn();
  }
}
