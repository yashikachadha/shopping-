import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CregisterProductComponent } from './cregister-product.component';

describe('CregisterProductComponent', () => {
  let component: CregisterProductComponent;
  let fixture: ComponentFixture<CregisterProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CregisterProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CregisterProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
