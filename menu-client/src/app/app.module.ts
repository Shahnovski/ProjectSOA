import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {ReactiveFormsModule} from '@angular/forms';
import { IngredientCreateComponent } from './Ingredient/ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './Ingredient/ingredient-edit/ingredient-edit.component';
import { IngredientListComponent } from './Ingredient/ingredient-list/ingredient-list.component';
import { DishListComponent } from './Dish/dish-list/dish-list.component';
import { DishCreateComponent } from './Dish/dish-create/dish-create.component';
import { DishEditComponent } from './Dish/dish-edit/dish-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    IngredientCreateComponent,
    IngredientEditComponent,
    IngredientListComponent,
    DishListComponent,
    DishCreateComponent,
    DishEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
