import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Curs3Component } from './curs3.component';

describe('Curs3Component', () => {
  let component: Curs3Component;
  let fixture: ComponentFixture<Curs3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Curs3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Curs3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
