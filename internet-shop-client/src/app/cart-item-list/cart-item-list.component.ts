import { Component, OnInit } from '@angular/core';
import {CartItem} from "../cartItem";
import {CartItemService} from "../services/cart-item.service";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-cart-item-list',
  templateUrl: './cart-item-list.component.html',
  styleUrls: ['./cart-item-list.component.css']
})
export class CartItemListComponent implements OnInit {

  cartItems: CartItem[] = [];
  totalCount: number = 0;
  totalCost: number = 0;

  constructor(private cartItemService: CartItemService,
              public modal: NgbActiveModal) { }

  ngOnInit(): void {
    this.loadCartItems();
  }

  loadCartItems() {
    this.cartItemService.getCartItemList().subscribe(
      data => {
        this.cartItems = data;
        this.calculateTotalCostAndCount();
      },
      error => {
        console.log(error);
      });
  }

  deleteCartItem(id: number) {
    this.cartItemService.deleteCartItem(id)
      .subscribe(
        data => {
          this.loadCartItems();
        },
        error => console.log(error));
  }

  deleteCartItemsByUserId(userId: number) {
    this.cartItemService.deleteCartItemsByUserId(userId)
      .subscribe(
        data => {
          this.loadCartItems();
        },
        error => console.log(error));
  }

  updateIngredient(id: number, cartItem: CartItem) {
    this.cartItemService.updateCartItem(id, cartItem)
      .subscribe(data => {
          this.loadCartItems();
        },
        error => {
          console.log(error)
        })
  };

  calculateTotalCostAndCount() {
    this.totalCost = 0;
    this.totalCount = 0;
    this.cartItems.forEach(item => {
      this.totalCount += item.cartItemCount;
      this.totalCost += item.ingredientPrice * item.cartItemCount;
    })
  }

}
