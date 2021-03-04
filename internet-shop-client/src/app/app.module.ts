import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IngredientCreateComponent } from './ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import {HttpClientModule} from '@angular/common/http';
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    IngredientCreateComponent,
    IngredientEditComponent,
    IngredientListComponent
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
