import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RedirectToMenuComponent } from './redirect-to-menu.component';

describe('RedirectToMenuComponent', () => {
  let component: RedirectToMenuComponent;
  let fixture: ComponentFixture<RedirectToMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RedirectToMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RedirectToMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
