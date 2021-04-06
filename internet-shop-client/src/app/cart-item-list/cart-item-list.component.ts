import { Component, OnInit } from '@angular/core';
import {CartItem} from "../cartItem";
import {CartItemService} from "../services/cart-item.service";
import {NgbActiveModal, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {PaymentComponent} from "../payment/payment.component";
import {AuthService} from "../services/auth.service";

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
              public modal: NgbActiveModal,
              public authService: AuthService,
              private modalService: NgbModal) { }

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

  deleteCartItemsByUserId(username: string) {
    this.cartItemService.deleteCartItemsByUserId(this.authService.getUserName())
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

  moveToPayment() {
    const ref = this.modalService.open(PaymentComponent, { centered: true });
    ref.componentInstance.totalCost = this.totalCost;
    ref.result.then((result) => {
      if (result === 'Cancel') {
        this.loadCartItems();
      }
      else {
        this.deleteCartItemsByUserId(this.authService.getUserName());
        this.modal.close('Save');
      }
      },
      (cancel) => {
        this.loadCartItems();
      });
  }

}
