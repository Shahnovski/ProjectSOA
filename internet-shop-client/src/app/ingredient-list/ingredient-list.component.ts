import { Component, OnInit } from '@angular/core';
import {ShopItem} from '../shopItem';
import {IngredientItemService} from '../services/ingredient-item.service';
import {CartItemService} from '../services/cart-item.service';
import { AppComponent } from '../app.component';
import {AuthService} from '../services/auth.service';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.scss']
})
export class IngredientListComponent implements OnInit {

  ingredients: ShopItem[] = [];

  constructor(private ingredientItemService: IngredientItemService,
              private cartItemService: CartItemService,
              public authService: AuthService) { }

  ngOnInit(): void {
    this.loadIngredients();
    this.loadCartItemsCount(this.authService.getUserName());
  }

  loadIngredients() {
    this.ingredientItemService.getIngredientList().subscribe(
      data => {
        this.ingredients = data;
      },
      error => {
        console.log(error);
      });
  }

  deleteIngredient(id: number) {
    this.ingredientItemService.deleteIngredient(id)
      .subscribe(
        data => {
          this.loadIngredients();
        },
        error => console.log(error));
  }

  addIngredientToCart(cartItem: { ingredientId: number; cartItemCount: number }) {
    this.cartItemService.createCartItem(cartItem).subscribe(
      data => {
        this.loadCartItemsCount(this.authService.getUserName());
      },
      error => {
        console.log(error);
      });
  }

  loadCartItemsCount(username: string) {
    this.cartItemService.getCartItemsCount(username).subscribe(
      data => {
        AppComponent.cartItemsCount = data;
      },
      error => {
        console.log(error);
      });
  }

}
