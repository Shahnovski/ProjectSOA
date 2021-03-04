import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {ShopItem} from '../shopItem';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class IngredientItemService {
  private appUrl = environment.appUrl;
  private apiUrl = 'api/v1/ingredients';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) { }

  getIngredientList(): Observable<ShopItem[]> {
    return this.http.get<ShopItem[]>(`${this.appUrl + this.apiUrl}`);
  }

  getIngredient(id: number): Observable<ShopItem> {
    return this.http.get<ShopItem>(`${this.appUrl + this.apiUrl}/${id}`);
  }

  createIngredient(ingredient: object): Observable<ShopItem> {
    return this.http.post<ShopItem>(`${this.appUrl + this.apiUrl}`, ingredient, this.httpOptions);
  }

  updateIngredient(id: number, ingredient: object): Observable<ShopItem> {
    return this.http.put<ShopItem>(`${this.appUrl + this.apiUrl}/${id}`, ingredient, this.httpOptions);
  }

  deleteIngredient(id: number): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}/${id}`, {responseType: 'text'});
  }
}
