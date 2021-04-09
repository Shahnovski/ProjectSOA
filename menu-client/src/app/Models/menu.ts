import { Dish } from './dish';

export class Menu {
  menuId: number = 0;
  timeOfDayId: number = 0;
  timeOfDayName: string = '';
  dayOfWeekId: number = 0;
  dayOfWeekName: string = '';
  dishId: number = 0;
  dish: Dish = new Dish();
}
