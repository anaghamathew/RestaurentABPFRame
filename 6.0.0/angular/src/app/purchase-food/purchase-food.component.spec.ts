import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseFoodComponent } from './purchase-food.component';

describe('PurchaseFoodComponent', () => {
  let component: PurchaseFoodComponent;
  let fixture: ComponentFixture<PurchaseFoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseFoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseFoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
