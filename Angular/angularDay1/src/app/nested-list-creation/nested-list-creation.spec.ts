import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NestedListCreation } from './nested-list-creation';

describe('NestedListCreation', () => {
  let component: NestedListCreation;
  let fixture: ComponentFixture<NestedListCreation>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NestedListCreation]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NestedListCreation);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
