import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {CartItem} from "../cartItem";

@Injectable({
  providedIn: 'root'
})
export class CartItemService {
  private appUrl = environment.appUrl;
  private apiUrl = 'api/v1/cartItems';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) { }

  getCartItemList(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(`${this.appUrl + this.apiUrl}`);
  }

  getCartItem(id: number): Observable<CartItem> {
    return this.http.get<CartItem>(`${this.appUrl + this.apiUrl}/${id}`);
  }

  createCartItem(cartItem: object): Observable<CartItem> {
    return this.http.post<CartItem>(`${this.appUrl + this.apiUrl}`, cartItem, this.httpOptions);
  }

  updateCartItem(id: number, cartItem: object): Observable<CartItem> {
    return this.http.put<CartItem>(`${this.appUrl + this.apiUrl}/${id}`, cartItem, this.httpOptions);
  }

  deleteCartItem(id: number): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}/${id}`, {responseType: 'text'});
  }

  deleteCartItemsByUserId(username: string): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}/deleteByUserId/${username}`, {responseType: 'text'});
  }

  getCartItemsCount(username: string): Observable<number> {
    return this.http.get<number>(`${this.appUrl + this.apiUrl}/cartItemsCount/${username}`);
  }
}
