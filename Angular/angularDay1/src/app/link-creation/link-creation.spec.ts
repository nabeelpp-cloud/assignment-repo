import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LinkCreation } from './link-creation';

describe('LinkCreation', () => {
  let component: LinkCreation;
  let fixture: ComponentFixture<LinkCreation>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LinkCreation]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LinkCreation);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
