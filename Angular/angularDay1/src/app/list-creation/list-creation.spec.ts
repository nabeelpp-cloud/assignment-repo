import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCreation } from './list-creation';

describe('ListCreation', () => {
  let component: ListCreation;
  let fixture: ComponentFixture<ListCreation>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListCreation]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListCreation);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
