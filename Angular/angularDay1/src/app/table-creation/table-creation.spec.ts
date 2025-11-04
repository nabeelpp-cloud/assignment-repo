import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableCreation } from './table-creation';

describe('TableCreation', () => {
  let component: TableCreation;
  let fixture: ComponentFixture<TableCreation>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TableCreation]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableCreation);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
