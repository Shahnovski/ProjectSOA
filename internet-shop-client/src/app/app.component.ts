import { Component } from '@angular/core';
import {CartItemListComponent} from "./cart-item-list/cart-item-list.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {CartItemService} from "./services/cart-item.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'internet-shop-client';

  static cartItemsCount: number = 0;

  constructor(private cartItemService: CartItemService,
              private modalService: NgbModal) {
    this.loadCartItemsCount(1);
  }

  loadCartItemsCount(userId: number) {
    this.cartItemService.getCartItemsCount(1).subscribe(
      data => {
        AppComponent.cartItemsCount = data;
      },
      error => {
        console.log(error)
      })
  }

  openCart() {
    const ref = this.modalService.open(CartItemListComponent, { centered: true });
    ref.result.then(() => {
        this.loadCartItemsCount(1);
      },
      (cancel) => {
        this.loadCartItemsCount(1);
      });
  }

  getCartItemsCount() : number {
    return AppComponent.cartItemsCount;
  }
}
