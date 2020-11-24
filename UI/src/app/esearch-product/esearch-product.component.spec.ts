import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EsearchProductComponent } from './esearch-product.component';

describe('EsearchProductComponent', () => {
  let component: EsearchProductComponent;
  let fixture: ComponentFixture<EsearchProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EsearchProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EsearchProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
