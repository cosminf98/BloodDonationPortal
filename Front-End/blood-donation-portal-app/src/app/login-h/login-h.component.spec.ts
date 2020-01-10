import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginHComponent } from './login-h.component';

describe('LoginHComponent', () => {
  let component: LoginHComponent;
  let fixture: ComponentFixture<LoginHComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginHComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginHComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
