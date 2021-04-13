import {Component, OnInit} from '@angular/core';
import {CartItemListComponent} from "./cart-item-list/cart-item-list.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {CartItemService} from "./services/cart-item.service";
import {AuthService} from "./services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'internet-shop-client';

  static cartItemsCount: number = 0;

  constructor(private cartItemService: CartItemService,
              private modalService: NgbModal,
              private authService: AuthService,
              private router: Router) {
    this.loadCartItemsCount(this.authService.getUserName());
  }

  ngOnInit() {
    if (localStorage.getItem('authToken')) {
      this.authService.setUserDetails();
    }
  }

  loadCartItemsCount(username: string) {
    this.cartItemService.getCartItemsCount(this.authService.getUserName()).subscribe(
      data => {
        AppComponent.cartItemsCount = data;
      },
      error => {
        console.log(error);
      });
  }

  openCart() {
    const ref = this.modalService.open(CartItemListComponent, { centered: true });
    ref.result.then(() => {
        this.loadCartItemsCount(this.authService.getUserName());
      },
      (cancel) => {
        this.loadCartItemsCount(this.authService.getUserName());
      });
  }

  getCartItemsCount(): number {
    return AppComponent.cartItemsCount;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(["login"]);
  }

  getAuthService(): AuthService {
    return this.authService;
  }
}
