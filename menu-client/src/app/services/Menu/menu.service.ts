import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Menu } from '../../Models/menu';
import { Dish } from '../../Models/dish';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private appUrl = environment.appUrl;
  private apiUrl = 'api/menu';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) { }

  getMenuList(): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.appUrl + this.apiUrl}`);
  }

  getMenu(id: number): Observable<Menu> {
    return this.http.get<Menu>(`${this.appUrl + this.apiUrl}/${id}`);
  }

  createMenu(menu: object): Observable<Menu> {
    return this.http.post<Menu>(`${this.appUrl + this.apiUrl}`, menu, this.httpOptions);
  }

  updateMenu(id: number, menu: object): Observable<Menu> {
    return this.http.put<Menu>(`${this.appUrl + this.apiUrl}/${id}`, menu, this.httpOptions);
  }

  deleteMenu(id: number): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}/${id}`, {responseType: 'text'});
  }

  deleteAllMenus(): Observable<any> {
    return this.http.delete(`${this.appUrl + this.apiUrl}`, {responseType: 'text'});
  }

  postIngredientsToCard(dishes: Dish[]): Observable<any> {
    return this.http.post<Menu>(`${this.appUrl + this.apiUrl}/toCart`, dishes, this.httpOptions);
  }
}


