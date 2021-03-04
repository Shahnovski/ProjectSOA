import { Component, OnInit } from '@angular/core';
import {ShopItem} from '../shopItem';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {IngredientItemService} from '../services/ingredient-item.service';

@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.scss']
})
export class IngredientEditComponent implements OnInit {

  ingredient: ShopItem = new ShopItem();

  ingredientForm: FormGroup  = this.fb.group({
    id: [this.route.snapshot.params["id"], Validators.required ],
    ingredientName: ['', Validators.required ],
    ingredientCode: ['', [Validators.required, Validators.pattern('^[1-9]\\d*$')]],
    ingredientCost: ['', [Validators.required, Validators.pattern('^[0-9]*[.,]?[0-9]+$')]]
  });

  incorrectIngredientCode = false;

  constructor(private ingredientService: IngredientItemService,
              private fb: FormBuilder,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getIngredientDetails(this.route.snapshot.params["id"]);
  }

  getIngredientDetails(id: number) {
    this.ingredientService.getIngredient(id).subscribe(
      data => {
        this.ingredient = data;
      },
      error => console.log(error));
  }

  updateIngredient() {
    this.ingredientService.updateIngredient(this.route.snapshot.params["id"], this.ingredient)
      .subscribe(data => {
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
    this.updateIngredient();
  }

}
