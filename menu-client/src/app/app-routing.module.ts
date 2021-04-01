import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IngredientListComponent } from './Ingredient/ingredient-list/ingredient-list.component';
import { IngredientCreateComponent } from './Ingredient/ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './Ingredient/ingredient-edit/ingredient-edit.component';
import {DishListComponent} from './Dish/dish-list/dish-list.component';

const routes: Routes = [
  { path: '', component: IngredientListComponent, pathMatch: 'full' },
  { path: 'add-ingredient', component: IngredientCreateComponent },
  { path: 'edit-ingredient/:id', component: IngredientEditComponent },
  { path: 'list-dish', component: DishListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
