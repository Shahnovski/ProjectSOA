import { Component, OnInit } from '@angular/core';
import {Ingredient} from "../ingredient";
import {IngredientService} from "../services/ingredient.service";
import {AuthService} from '../services/auth.service';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.css']
})
export class IngredientListComponent implements OnInit {

  ingredients: Ingredient[] = [];

  constructor(private ingredientService: IngredientService,
              public authService: AuthService) { }

  ngOnInit(): void {
    this.loadIngredients();
  }

  loadIngredients() {
    this.ingredientService.getIngredientList().subscribe(
      data => {
        this.ingredients = data;
      },
      error => {
        console.log(error);
      });
  }

  deleteIngredient(id: number) {
    this.ingredientService.deleteIngredient(id)
      .subscribe(
        data => {
          this.loadIngredients();
        },
        error => console.log(error));
  }

}
