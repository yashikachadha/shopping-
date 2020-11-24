import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FcartactionsComponent } from './fcartactions.component';

describe('FcartactionsComponent', () => {
  let component: FcartactionsComponent;
  let fixture: ComponentFixture<FcartactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FcartactionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FcartactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
