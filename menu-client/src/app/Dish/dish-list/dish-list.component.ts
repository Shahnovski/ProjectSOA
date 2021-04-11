import { Component, OnInit } from '@angular/core';
import { Dish } from '../../Models/dish';
import { DishService } from '../../services/Dish/dish.service';
import {AuthService} from '../../services/authentication/auth.service';

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {
  dishes: Dish[] = [];

  constructor(private dishService: DishService,
              public authService: AuthService) { }

  ngOnInit(): void {
    this.loadDishes();
  }

  loadDishes() {
    this.dishService.getDishList().subscribe(
      data => {
        this.dishes = data;
        console.log(this.dishes);
      },
      error => {
        console.log(error);
      });
  }

  deleteDish(id: number) {
    console.log(id);
    this.dishService.deleteDish(id)
      .subscribe(
        data => {
          this.loadDishes();
        },
        error => console.log(error));
  }
}
