import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterDComponent } from './register-d.component';

describe('RegisterDComponent', () => {
  let component: RegisterDComponent;
  let fixture: ComponentFixture<RegisterDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
