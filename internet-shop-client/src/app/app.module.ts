import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IngredientCreateComponent } from './ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CartItemListComponent } from './cart-item-list/cart-item-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    IngredientCreateComponent,
    IngredientEditComponent,
    IngredientListComponent,
    CartItemListComponent
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        NgbModule,
        FormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
