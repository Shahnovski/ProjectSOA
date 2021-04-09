import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-redirect-to-shop',
  templateUrl: './redirect-to-shop.component.html',
  styleUrls: ['./redirect-to-shop.component.css']
})
export class RedirectToShopComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    window.setTimeout(this.myFunction, 2000);

  }

  myFunction(): void {
    window.location.href = 'http://localhost:4203/';
  }
}
