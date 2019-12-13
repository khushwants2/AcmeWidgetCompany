import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserlistdetailComponent } from './userlistdetail.component';

describe('UserlistdetailComponent', () => {
  let component: UserlistdetailComponent;
  let fixture: ComponentFixture<UserlistdetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserlistdetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserlistdetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
