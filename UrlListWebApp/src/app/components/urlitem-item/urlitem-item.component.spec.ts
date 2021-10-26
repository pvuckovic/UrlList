import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlitemItemComponent } from './urlitem-item.component';

describe('UrlitemItemComponent', () => {
  let component: UrlitemItemComponent;
  let fixture: ComponentFixture<UrlitemItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrlitemItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UrlitemItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
