import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeapYearFinder } from './leap-year-finder';

describe('LeapYearFinder', () => {
  let component: LeapYearFinder;
  let fixture: ComponentFixture<LeapYearFinder>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LeapYearFinder]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeapYearFinder);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
