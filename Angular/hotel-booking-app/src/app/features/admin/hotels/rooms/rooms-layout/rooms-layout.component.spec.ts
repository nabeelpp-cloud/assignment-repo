import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomsLayoutComponent } from './rooms-layout.component';

describe('RoomsLayoutComponent', () => {
  let component: RoomsLayoutComponent;
  let fixture: ComponentFixture<RoomsLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RoomsLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoomsLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
