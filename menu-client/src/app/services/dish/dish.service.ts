import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Dish} from '../../Models/dish';

@Injectable({
  providedIn: 'root'
})
export class DishService {

  private appUrl = environment.appUrl;
  private apiUrl = 'api/dishes';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) { }

  getDishList(): Observable<Dish[]> {
    return this.http.get<Dish[]>(`${this.appUrl + this.apiUrl}`);
  }

  getDish(id: number): Observable<Dish> {
    return this.http.get<Dish>(`${this.appUrl + this.apiUrl}/${id}`);
  }

  createDish(dish: object): Observable<Dish> {
    return this.http.post<Dish>(`${this.appUrl + this.apiUrl}`, dish, this.httpOptions);
  }

  updateDish(id: number, dish: object): Observable<Dish> {
    return this.http.put<Dish>(`${this.appUrl + this.apiUrl}/${id}`, dish, this.httpOptions);
  }

  deleteDish(id: number): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}/${id}`, {responseType: 'text'});
  }
}

