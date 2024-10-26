import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanAddComponent } from './loan-add.component';

describe('LoanAddComponent', () => {
  let component: LoanAddComponent;
  let fixture: ComponentFixture<LoanAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoanAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
