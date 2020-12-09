import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentUser!: JSON;
  constructor() {
    // @ts-ignore
    this.currentUser = JSON.parse(localStorage.getItem("currentUser"));
  }

  ngOnInit(): void {
  }

}
