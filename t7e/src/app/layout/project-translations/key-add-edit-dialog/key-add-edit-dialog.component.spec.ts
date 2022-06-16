import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KeyAddEditDialogComponent } from './key-add-edit-dialog.component';

describe('KeyAddEditDialogComponent', () => {
  let component: KeyAddEditDialogComponent;
  let fixture: ComponentFixture<KeyAddEditDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KeyAddEditDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KeyAddEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
