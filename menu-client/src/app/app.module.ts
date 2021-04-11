import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IngredientCreateComponent } from './Ingredient/ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './Ingredient/ingredient-edit/ingredient-edit.component';
import { IngredientListComponent } from './Ingredient/ingredient-list/ingredient-list.component';
import { DishListComponent } from './Dish/dish-list/dish-list.component';
import { DishCreateComponent } from './Dish/dish-create/dish-create.component';
import { DishEditComponent } from './Dish/dish-edit/dish-edit.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { MenuListComponent } from './Menu/menu-list/menu-list.component';
import { RedirectToShopComponent } from './Others/redirect-to-shop/redirect-to-shop.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import {HttpInterceptorService} from './services/authentication/http-interceptor.service';
import {ErrorInterceptorService} from './services/authentication/error-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    IngredientCreateComponent,
    IngredientEditComponent,
    IngredientListComponent,
    DishListComponent,
    DishCreateComponent,
    DishEditComponent,
    MenuListComponent,
    RedirectToShopComponent,
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgMultiSelectDropDownModule,
    FormsModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: HttpInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
