import { Component, OnInit } from '@angular/core';
import {Dish} from '../../Models/dish';
import {Ingredient} from '../../Models/ingredient';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {DishService} from '../../services/Dish/dish.service';
import {IngredientService} from '../../services/Ingredient/ingredient.service';
import {ActivatedRoute, Router} from '@angular/router';
import {noUndefined} from '@angular/compiler/src/util';

@Component({
  selector: 'app-dish-edit',
  templateUrl: './dish-edit.component.html',
  styleUrls: ['./dish-edit.component.css']
})
export class DishEditComponent implements OnInit {
  dish: Dish = new Dish();
  ingredients: Ingredient[] = [];
  submitted = false;
  dropdownSettingsIngredients = {};
  flagIngredientsLoad = false;
  dishIngredients: Ingredient[] = [];

  dishForm: FormGroup = this.fb.group({
    dishName: ['', Validators.required ],
    ingredients: ['', Validators.required ]
  });

  constructor(private dishService: DishService,
              private ingredientService: IngredientService,
              private fb: FormBuilder,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.ingredientService.getIngredientList().subscribe(
      data => {
        this.ingredients = data;
      },
      error => {
        console.log(error);
      });
    this.getDishDetails(this.route.snapshot.params.id);
    this.setDropdownSettingsCategories();
  }

  getDishDetails(id: number): void {
    this.dishService.getDish(id).subscribe(
      data => {
        this.dish = data;
        this.setEqualityIngreidents();
        this.dishIngredients = data.ingredients;
      },
      error => console.log(error));
  }

  updateDish(): void {
    this.dish.ingredients = this.dishIngredients;
    this.dishService.updateDish(this.route.snapshot.params.id, this.dish)
      .subscribe(data => {
        this.router.navigate(['']);
      }, error => console.log(error));
  }

  onSubmit(): void {
    this.updateDish();
  }

  setDropdownSettingsCategories(): void {
    this.dropdownSettingsIngredients = {
      singleSelection: false,
      idField: 'ingredientId',
      textField: 'ingredientName',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }

  setEqualityIngreidents(): void {
    let i: number;
    let j: number;
    if (!this.flagIngredientsLoad) {
      this.flagIngredientsLoad = true;
      return;
    }
    for (i = 0; i < this.dish.ingredients.length; i++) {
      for (j = 0; j < this.ingredients.length; j++) {
        if (this.dish.ingredients[i].ingredientId === this.ingredients[j].ingredientId) {
          this.dish.ingredients[i] = this.ingredients[j];
        }
      }
    }
  }

  countsAreCorrect(): boolean {
    return this.dishIngredients.length === 0 || this.dishIngredients.every(i => i.amount >= 0 && Number.isInteger(i.amount));
  }

  refreshIngredients(): any {
    this.dishIngredients.forEach( i => {
      const buf = this.dish.ingredients.filter(ingr => ingr.ingredientId === i.ingredientId);
      if (buf.length === 0) {
        i.ingredientId = 0;
      }
    });
    this.dish.ingredients.forEach( i => {
      const buf = this.dishIngredients.filter(ingr => ingr.ingredientId === i.ingredientId);
      if (buf.length === 0) {
        this.dishIngredients.push(i);
      }
    });
    this.dishIngredients = this.dishIngredients.filter(i => i.ingredientId !== 0);
  }

  updateDishIngredients(): void {
    this.refreshIngredients().subscribe(() =>
      this.dishIngredients = this.dishIngredients.filter(i => i.ingredientId !== 0)
    );
  }

}
