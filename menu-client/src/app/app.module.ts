import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IngredientCreateComponent } from './Ingredient/ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './Ingredient/ingredient-edit/ingredient-edit.component';
import { IngredientListComponent } from './Ingredient/ingredient-list/ingredient-list.component';
import { DishListComponent } from './Dish/dish-list/dish-list.component';
import { DishCreateComponent } from './Dish/dish-create/dish-create.component';
import { DishEditComponent } from './Dish/dish-edit/dish-edit.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { MenuCreateComponent } from './Menu/menu-create/menu-create.component';
import { MenuEditComponent } from './Menu/menu-edit/menu-edit.component';
import { MenuListComponent } from './Menu/menu-list/menu-list.component';

@NgModule({
  declarations: [
    AppComponent,
    IngredientCreateComponent,
    IngredientEditComponent,
    IngredientListComponent,
    DishListComponent,
    DishCreateComponent,
    DishEditComponent,
    MenuCreateComponent,
    MenuEditComponent,
    MenuListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgMultiSelectDropDownModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
