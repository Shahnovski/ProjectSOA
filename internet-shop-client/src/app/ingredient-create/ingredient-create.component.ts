import { Component, OnInit } from '@angular/core';
import {ShopItem} from '../shopItem';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {IngredientItemService} from '../services/ingredient-item.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-ingredient-create',
  templateUrl: './ingredient-create.component.html',
  styleUrls: ['./ingredient-create.component.scss']
})
export class IngredientCreateComponent implements OnInit {

  ingredient: ShopItem = new ShopItem();

  ingredientForm: FormGroup  = this.fb.group({
    ingredientName: ['', Validators.required ],
    ingredientCode: ['', [Validators.required, Validators.pattern('^[1-9]\\d*$')]],
    ingredientCost: ['', [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]]
  });

  submitted = false;
  incorrectIngredientCode = false;

  constructor(private ingredientService: IngredientItemService,
              private fb: FormBuilder,
              private router: Router) { }


  ngOnInit(): void {
  }

  save() {
    this.ingredientService.createIngredient(this.ingredient).subscribe(
      data => {
        this.incorrectIngredientCode = false;
        this.ingredient = new ShopItem();
        this.ingredient = data;
        this.ingredient = new ShopItem();
        this.router.navigate(['']);
      },
      error => {
        if (error.error == 'This ingredientCode is already exists!') {
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

