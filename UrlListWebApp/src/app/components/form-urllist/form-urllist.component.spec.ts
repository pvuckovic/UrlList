import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUrllistComponent } from './form-urllist.component';

describe('FormUrllistComponent', () => {
  let component: FormUrllistComponent;
  let fixture: ComponentFixture<FormUrllistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUrllistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUrllistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
