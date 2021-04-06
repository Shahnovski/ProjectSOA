import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import { IngredientCreateComponent } from './ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';
import {LoginComponent} from "./login/login.component";
import {RegistrationComponent} from "./registration/registration.component";
import {AuthGuardService} from "./guards/auth-guard.service";
import {AdminGuardService} from "./guards/admin-guard.service";

const routes: Routes = [
  { path: '', component: IngredientListComponent, pathMatch: 'full', canActivate: [AuthGuardService] },
  { path: 'add-ingredient', component: IngredientCreateComponent, canActivate: [AdminGuardService] },
  { path: 'edit-ingredient/:id', component: IngredientEditComponent, canActivate: [AdminGuardService] },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
