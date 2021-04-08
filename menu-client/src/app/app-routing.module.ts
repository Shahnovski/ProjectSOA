import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IngredientListComponent } from './Ingredient/ingredient-list/ingredient-list.component';
import { IngredientCreateComponent } from './Ingredient/ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './Ingredient/ingredient-edit/ingredient-edit.component';
import { DishListComponent } from './Dish/dish-list/dish-list.component';
import { DishCreateComponent } from './Dish/dish-create/dish-create.component';
import { DishEditComponent } from './Dish/dish-edit/dish-edit.component';
import { MenuListComponent } from './Menu/menu-list/menu-list.component';

const routes: Routes = [
  { path: '', component: MenuListComponent, pathMatch: 'full' },
  { path: 'list-ingredients', component: IngredientListComponent },
  { path: 'add-ingredient', component: IngredientCreateComponent },
  { path: 'edit-ingredient/:id', component: IngredientEditComponent },
  { path: 'list-dish', component: DishListComponent },
  { path: 'add-dish', component: DishCreateComponent },
  { path: 'edit-dish/:id', component: DishEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
