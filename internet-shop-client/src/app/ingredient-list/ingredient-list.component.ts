import { Component, OnInit } from '@angular/core';
import {ShopItem} from '../shopItem';
import {IngredientItemService} from '../services/ingredient-item.service';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.scss']
})
export class IngredientListComponent implements OnInit {

  ingredients: ShopItem[] = [];

  constructor(private ingredientItemService: IngredientItemService) { }

  ngOnInit(): void {
    this.loadIngredients();
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

}
