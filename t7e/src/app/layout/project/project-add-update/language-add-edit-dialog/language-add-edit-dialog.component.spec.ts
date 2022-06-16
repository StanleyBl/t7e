import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LanguageAddEditDialogComponent } from './language-add-edit-dialog.component';

describe('LanguageAddEditDialogComponent', () => {
  let component: LanguageAddEditDialogComponent;
  let fixture: ComponentFixture<LanguageAddEditDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LanguageAddEditDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LanguageAddEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
