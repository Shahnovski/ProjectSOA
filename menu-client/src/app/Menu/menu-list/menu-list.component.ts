import { Component, OnInit } from '@angular/core';
import { Menu } from '../../Models/menu';
import { Dish } from '../../Models/dish';
import { MenuService } from '../../services/Menu/menu.service';
import { DishService } from '../../services/Dish/dish.service';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.css']
})
export class MenuListComponent implements OnInit {
  menus: Menu[] = [];
  dishes: Dish[] = [];

  defaultDish: Dish = new Dish();

  monday = 'Monday';
  tuesday = 'Tuesday';
  wednesday = 'Wednesday';
  thursday = 'Thursday';
  friday = 'Friday';
  saturday = 'Saturday';
  sunday = 'Sunday';

  breakfast = 'Breakfast';
  lunch = 'Lunch';
  dinner = 'Dinner';

  menuMondayBreakfast = new Menu();
  menuMondayLunch = new Menu();
  menuMondayDinner = new Menu();

  menuTuesdayBreakfast = new Menu();
  menuTuesdayLunch = new Menu();
  menuTuesdayDinner = new Menu();

  menuWednesdayBreakfast = new Menu();
  menuWednesdayLunch = new Menu();
  menuWednesdayDinner = new Menu();

  menuThursdayBreakfast = new Menu();
  menuThursdayLunch = new Menu();
  menuThursdayDinner = new Menu();

  menuFridayBreakfast = new Menu();
  menuFridayLunch = new Menu();
  menuFridayDinner = new Menu();

  menuSaturdayBreakfast = new Menu();
  menuSaturdayLunch = new Menu();
  menuSaturdayDinner = new Menu();

  menuSundayBreakfast = new Menu();
  menuSundayLunch = new Menu();
  menuSundayDinner = new Menu();

  constructor(
    private menuService: MenuService,
    private dishService: DishService,
  ) {}

  ngOnInit(): void {
    this.loadMenus();
    this.loadDishes();
  }

  loadDishes(): void {
    this.dishService.getDishList().subscribe(
      data => this.dishes = data,
      error => console.log(error)
    );
  }

  loadMenus(): void {
    this.menuService.getMenuList().subscribe(
      data => {
        this.menus = data;
        console.log(this.menus);
        this.fillMenuItems();
      },
      error => console.log(error)
    );
  }

  createMenu(menu: Menu): void {
    this.menuService.createMenu(menu).subscribe(
      data => this.loadMenus(),
      error => console.log(error)
    );
  }

  updateMenu(id: number, menu: Menu): void {
    this.menuService.updateMenu(id, menu).subscribe(
      data => this.loadMenus(),
      error => console.log(error)
    );
  }

  deleteMenu(id: number): void {
    this.menuService.deleteMenu(id).subscribe(
      data => this.loadMenus(),
      error => console.log(error)
    );
  }

  onClearMenu(): void {
    this.menuService.deleteAllMenus().subscribe(
      data => this.loadMenus(),
      error => console.log(error)
    );
  }

  fillMenuItems(): void {

    this.menuMondayBreakfast = new Menu();
    this.menuMondayLunch = new Menu();
    this.menuMondayDinner = new Menu();

    this.menuTuesdayBreakfast = new Menu();
    this.menuTuesdayLunch = new Menu();
    this.menuTuesdayDinner = new Menu();

    this.menuWednesdayBreakfast = new Menu();
    this.menuWednesdayLunch = new Menu();
    this.menuWednesdayDinner = new Menu();

    this.menuThursdayBreakfast = new Menu();
    this.menuThursdayLunch = new Menu();
    this.menuThursdayDinner = new Menu();

    this.menuFridayBreakfast = new Menu();
    this.menuFridayLunch = new Menu();
    this.menuFridayDinner = new Menu();

    this.menuSaturdayBreakfast = new Menu();
    this.menuSaturdayLunch = new Menu();
    this.menuSaturdayDinner = new Menu();

    this.menuSundayBreakfast = new Menu();
    this.menuSundayLunch = new Menu();
    this.menuSundayDinner = new Menu();

    this.menus.forEach(
      value => {

        if (value.dayOfWeekName === this.monday && value.timeOfDayName === this.breakfast) {
          this.menuMondayBreakfast = value;
        }

        if (value.dayOfWeekName === this.monday && value.timeOfDayName === this.lunch) {
          this.menuMondayLunch = value;
        }

        if (value.dayOfWeekName === this.monday && value.timeOfDayName === this.dinner) {
          this.menuMondayDinner = value;
        }

        if (value.dayOfWeekName === this.tuesday && value.timeOfDayName === this.breakfast) {
          this.menuTuesdayBreakfast = value;
        }

        if (value.dayOfWeekName === this.tuesday && value.timeOfDayName === this.lunch) {
          this.menuTuesdayLunch = value;
        }

        if (value.dayOfWeekName === this.tuesday && value.timeOfDayName === this.dinner) {
          this.menuTuesdayDinner = value;
        }

        if (value.dayOfWeekName === this.wednesday && value.timeOfDayName === this.breakfast) {
          this.menuWednesdayBreakfast = value;
        }

        if (value.dayOfWeekName === this.wednesday && value.timeOfDayName === this.lunch) {
          this.menuWednesdayLunch = value;
        }

        if (value.dayOfWeekName === this.wednesday && value.timeOfDayName === this.dinner) {
          this.menuWednesdayDinner = value;
        }

        if (value.dayOfWeekName === this.thursday && value.timeOfDayName === this.breakfast) {
          this.menuThursdayBreakfast = value;
        }

        if (value.dayOfWeekName === this.thursday && value.timeOfDayName === this.lunch) {
          this.menuThursdayLunch = value;
        }

        if (value.dayOfWeekName === this.thursday && value.timeOfDayName === this.dinner) {
          this.menuThursdayDinner = value;
        }

        if (value.dayOfWeekName === this.friday && value.timeOfDayName === this.breakfast) {
          this.menuFridayBreakfast = value;
        }

        if (value.dayOfWeekName === this.friday && value.timeOfDayName === this.lunch) {
          this.menuFridayLunch = value;
        }

        if (value.dayOfWeekName === this.friday && value.timeOfDayName === this.dinner) {
          this.menuFridayDinner = value;
        }

        if (value.dayOfWeekName === this.saturday && value.timeOfDayName === this.breakfast) {
          this.menuSaturdayBreakfast = value;
        }

        if (value.dayOfWeekName === this.saturday && value.timeOfDayName === this.lunch) {
          this.menuSaturdayLunch = value;
        }

        if (value.dayOfWeekName === this.saturday && value.timeOfDayName === this.dinner) {
          this.menuSaturdayDinner = value;
        }

        if (value.dayOfWeekName === this.sunday && value.timeOfDayName === this.breakfast) {
          this.menuSundayBreakfast = value;
        }

        if (value.dayOfWeekName === this.sunday && value.timeOfDayName === this.lunch) {
          this.menuSundayLunch = value;
        }

        if (value.dayOfWeekName === this.sunday && value.timeOfDayName === this.dinner) {
          this.menuSundayDinner = value;
        }

      });
  }

  onSelectDish(menu: Menu, dishId: string, dayOfWeekName: string, timeOfDayName: string): void {
    const tempDish = this.dishes.filter(dish => dish.dishId === Number(dishId));
    if (dishId === '0' && menu != null && menu.menuId !== 0) {
      this.deleteMenu(menu.menuId);
    } else if (tempDish != null && menu != null && menu.menuId !== 0) {
      menu.dish = tempDish[0];
      menu.dishId = Number(dishId);
      this.updateMenu(menu.menuId, menu);
    } else if (tempDish != null && menu != null && menu.menuId === 0) {
      menu.dayOfWeekName = dayOfWeekName;
      menu.timeOfDayName = timeOfDayName;
      menu.dishId = Number(dishId);
      menu.dish = tempDish[0];
      this.createMenu(menu);
    }
  }

  getTotalDishCost(dish: Dish): number {
    let totalCost = 0;
    dish.ingredients.forEach(
      value => {
        totalCost += (value.ingredientCost * value.amount);
      }
    );
    return totalCost;
  }

  sendIngredientsToShop(): void {
    const dishes: Dish[] = [];

    this.menus.forEach(
      value => {
        dishes.push(value.dish);
      }
    );

    this.menuService.postIngredientsToCard(dishes).subscribe(
      data => console.log(data),
      error => console.log(error)
    );
  }
}
