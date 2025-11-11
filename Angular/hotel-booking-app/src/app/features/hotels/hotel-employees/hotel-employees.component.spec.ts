import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelEmployeesComponent } from './hotel-employees.component';

describe('HotelEmployeesComponent', () => {
  let component: HotelEmployeesComponent;
  let fixture: ComponentFixture<HotelEmployeesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelEmployeesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelEmployeesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
