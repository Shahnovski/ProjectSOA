import { TestBed } from '@angular/core/testing';

import { IngredientItemService } from './ingredient-item.service';

describe('IngredientItemService', () => {
  let service: IngredientItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IngredientItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
