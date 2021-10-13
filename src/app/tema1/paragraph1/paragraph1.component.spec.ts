import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Paragraph1Component } from './paragraph1.component';

describe('Paragraph1Component', () => {
  let component: Paragraph1Component;
  let fixture: ComponentFixture<Paragraph1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Paragraph1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Paragraph1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
