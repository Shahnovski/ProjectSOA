import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import { IngredientCreateComponent } from './ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';

const routes: Routes = [
  { path: '', component: IngredientListComponent, pathMatch: 'full' },
  { path: 'add-ingredient', component: IngredientCreateComponent },
  { path: 'edit-ingredient/:id', component: IngredientEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
