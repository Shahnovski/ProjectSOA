import { Component, OnInit } from '@angular/core';
import {IngredientService} from "../services/ingredient.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {Ingredient} from "../ingredient";

@Component({
  selector: 'app-ingredient-create',
  templateUrl: './ingredient-create.component.html',
  styleUrls: ['./ingredient-create.component.css']
})
export class IngredientCreateComponent implements OnInit {

  ingredient: Ingredient = new Ingredient();

  ingredientForm: FormGroup  = this.fb.group({
    ingredientName: ['', Validators.required ],
    ingredientCode: ['', [Validators.required, Validators.pattern('^[1-9]\\d*$')]],
    ingredientCalories: ['', [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]],
    ingredientProteins: ['', [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]],
    ingredientCarbohydrates: ['', [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]],
    ingredientFats: ['', [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]]
  });

  submitted = false;
  incorrectIngredientCode: boolean = false;

  constructor(private ingredientService: IngredientService,
              private fb: FormBuilder,
              private router: Router) { }


  ngOnInit(): void {
  }

  save() {
    this.ingredientService.createIngredient(this.ingredient).subscribe(
      data => {
        this.incorrectIngredientCode = false;
        this.ingredient = new Ingredient();
        this.ingredient = data;
        this.ingredient = new Ingredient();
        this.router.navigate(['']);
      },
      error => {
        if (error.error == "This ingredientCode is already exists!") {
          this.incorrectIngredientCode = true;
        }
        else {
          console.log(error)
        }
      });
  }

  onSubmit() {
    this.save();
  }

}
