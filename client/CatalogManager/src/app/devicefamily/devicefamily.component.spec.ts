import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicefamilyComponent } from './devicefamily.component';

describe('DevicefamilyComponent', () => {
  let component: DevicefamilyComponent;
  let fixture: ComponentFixture<DevicefamilyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DevicefamilyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DevicefamilyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
