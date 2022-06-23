import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslationKeyComponent } from './translation-key.component';

describe('TranslationKeyComponent', () => {
  let component: TranslationKeyComponent;
  let fixture: ComponentFixture<TranslationKeyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranslationKeyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TranslationKeyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
