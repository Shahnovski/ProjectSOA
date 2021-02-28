import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import { IngredientCreateComponent } from './ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    IngredientListComponent,
    IngredientCreateComponent,
    IngredientEditComponent
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
