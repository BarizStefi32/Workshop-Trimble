import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FourthparagraphComponent } from './fourthparagraph.component';

describe('FourthparagraphComponent', () => {
  let component: FourthparagraphComponent;
  let fixture: ComponentFixture<FourthparagraphComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FourthparagraphComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FourthparagraphComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
