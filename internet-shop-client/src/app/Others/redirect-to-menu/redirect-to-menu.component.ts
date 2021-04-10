import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-redirect-to-menu',
  templateUrl: './redirect-to-menu.component.html',
  styleUrls: ['./redirect-to-menu.component.css']
})
export class RedirectToMenuComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    window.setTimeout(this.myFunction, 2000);
  }

  myFunction(): void {
    window.location.href = 'http://localhost:4201/';
  }
}
