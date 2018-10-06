import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserInfoMenuComponent } from './user-info-menu.component';

describe('UserInfoMenuComponent', () => {
  let component: UserInfoMenuComponent;
  let fixture: ComponentFixture<UserInfoMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserInfoMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserInfoMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
