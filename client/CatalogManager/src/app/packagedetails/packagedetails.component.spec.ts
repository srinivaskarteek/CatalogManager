import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PackageDetailsComponent } from './packagedetails.component';

describe('HomeComponent', () => {
  let component: PackageDetailsComponent;
  let fixture: ComponentFixture<PackageDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PackageDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PackageDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
