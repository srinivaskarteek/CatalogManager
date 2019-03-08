import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PackagefamilyComponent } from './packagefamily.component';

describe('PackagefamilyComponent', () => {
  let component: PackagefamilyComponent;
  let fixture: ComponentFixture<PackagefamilyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PackagefamilyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PackagefamilyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
