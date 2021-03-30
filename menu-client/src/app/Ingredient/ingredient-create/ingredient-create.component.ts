import { Component, OnInit } from '@angular/core';
import {Ingredient} from '../../Models/ingredient';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {IngredientService} from '../../services/Ingredient/ingredient.service';

@Component({
  selector: 'app-ingredient-create',
  templateUrl: './ingredient-create.component.html',
  styleUrls: ['./ingredient-create.component.css']
})
export class IngredientCreateComponent implements OnInit {
  ingredient: Ingredient = new Ingredient();

  ingredientForm: FormGroup  = this.fb.group({
    ingredientName: ['', Validators.required ],
    ingredientCode: ['', [Validators.required, Validators.pattern('^[1-9]\\d*$')]]
  });

  submitted = false;
  incorrectIngredientCode: boolean = false;

  constructor(private ingredientService: IngredientService,
              private fb: FormBuilder,
              private router: Router) { }


  ngOnInit(): void {
  }

  save() {
    this.ingredient.ingredientCode = Number(this.ingredient.ingredientCode);
    this.ingredientService.createIngredient(this.ingredient).subscribe(
      data => {
        this.incorrectIngredientCode = false;
        this.ingredient = new Ingredient();
        this.ingredient = data;
        this.router.navigate(['']);
      },
      error => {
        if (error.error == "Ингредиент с таким кодом уже существует") {
          this.incorrectIngredientCode = true;
        }
        else {
          console.log(error);
        }
      });
  }

  onSubmit() {
    this.save();
  }
}
