import { Component, OnInit } from '@angular/core';
import {Dish} from '../../Models/dish';
import {Ingredient} from '../../Models/ingredient';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {IngredientService} from '../../services/Ingredient/ingredient.service';
import {Router} from '@angular/router';
import {DishService} from '../../services/Dish/dish.service';

@Component({
  selector: 'app-dish-create',
  templateUrl: './dish-create.component.html',
  styleUrls: ['./dish-create.component.css']
})
export class DishCreateComponent implements OnInit {
  dish: Dish = new Dish();
  ingredients: Ingredient[] = [];
  submitted = false;
  dropdownSettingsIngredients = {};
  dishIngredients: Ingredient[] = [];

  dishForm: FormGroup = this.fb.group({
    dishName: ['', Validators.required ],
    ingredients: ['', Validators.required ]
  });

  constructor(private dishService: DishService,
              private ingredientService: IngredientService,
              private fb: FormBuilder,
              private router: Router) { }

  ngOnInit(): void {
    this.ingredientService.getIngredientList().subscribe(
      data => {
        this.ingredients = data;
      },
      error => {
        console.log(error);
      });
    this.setDropdownSettingsCategories();
  }

  save(): void {
    this.dish.ingredients = this.dishIngredients;
    this.dishService.createDish(this.dish).subscribe(
      data => {
        this.dish = new Dish();
        this.router.navigate(['']);
      },
      error => console.log(error));
  }

  onSubmit(): void {
    this.save();
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

  countsAreCorrect(): boolean {
    const regexp = new RegExp('[1-9][0-9]+');
    return this.dishIngredients.length === 0 || this.dishIngredients.every(i => i.amount > 0 && Number.isInteger(i.amount));
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

  updateDishIngredientsForSelectAndDeselect(): void {
    this.refreshIngredients().subscribe(() =>
      this.dishIngredients = this.dishIngredients.filter(i => i.ingredientId !== 0)
    );
  }

  updateDishIngredientsForSelectAll(): void {
    this.ingredients.forEach( i => {
      const buf = this.dishIngredients.filter(ingr => ingr.ingredientId === i.ingredientId);
      if (buf.length === 0) {
        this.dishIngredients.push(i);
      }
    });
  }

  updateDishIngredientsForDeselectAll(): void {
    this.dishIngredients = [];
  }

}
