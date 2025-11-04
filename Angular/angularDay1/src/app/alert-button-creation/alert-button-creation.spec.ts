import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertButtonCreation } from './alert-button-creation';

describe('AlertButtonCreation', () => {
  let component: AlertButtonCreation;
  let fixture: ComponentFixture<AlertButtonCreation>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlertButtonCreation]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlertButtonCreation);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
