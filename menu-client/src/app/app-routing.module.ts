import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IngredientListComponent } from './Ingredient/ingredient-list/ingredient-list.component';
import { IngredientCreateComponent } from './Ingredient/ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './Ingredient/ingredient-edit/ingredient-edit.component';
import { DishListComponent } from './Dish/dish-list/dish-list.component';
import { DishCreateComponent } from './Dish/dish-create/dish-create.component';
import { DishEditComponent } from './Dish/dish-edit/dish-edit.component';
import { MenuListComponent } from './Menu/menu-list/menu-list.component';
import { RedirectToShopComponent } from './Others/redirect-to-shop/redirect-to-shop.component';
import {AuthGuardService} from './guards/auth-guard.service';
import {AdminGuardService} from './guards/admin-guard.service';
import {LoginComponent} from './login/login.component';
import {RegistrationComponent} from './registration/registration.component';

const routes: Routes = [
  { path: '', component: MenuListComponent, pathMatch: 'full', canActivate: [AuthGuardService] },
  { path: 'list-ingredients', component: IngredientListComponent, canActivate: [AdminGuardService] },
  { path: 'add-ingredient', component: IngredientCreateComponent, canActivate: [AdminGuardService] },
  { path: 'edit-ingredient/:id', component: IngredientEditComponent, canActivate: [AdminGuardService] },
  { path: 'list-dish', component: DishListComponent, canActivate: [AuthGuardService] },
  { path: 'add-dish', component: DishCreateComponent, canActivate: [AdminGuardService] },
  { path: 'edit-dish/:id', component: DishEditComponent, canActivate: [AdminGuardService] },
  { path: 'redirect-to-shop', component: RedirectToShopComponent, canActivate: [AuthGuardService] },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
