import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterHComponent } from './register-h.component';

describe('RegisterHComponent', () => {
  let component: RegisterHComponent;
  let fixture: ComponentFixture<RegisterHComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterHComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterHComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
