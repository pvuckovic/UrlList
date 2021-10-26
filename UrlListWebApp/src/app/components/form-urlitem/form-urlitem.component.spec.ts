import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUrlitemComponent } from './form-urlitem.component';

describe('FormUrlitemComponent', () => {
  let component: FormUrlitemComponent;
  let fixture: ComponentFixture<FormUrlitemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUrlitemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUrlitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
