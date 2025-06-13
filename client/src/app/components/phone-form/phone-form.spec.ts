import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneForm } from './phone-form';

describe('PhoneForm', () => {
  let component: PhoneForm;
  let fixture: ComponentFixture<PhoneForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PhoneForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhoneForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
