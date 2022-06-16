import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectTranslationsComponent } from './project-translations.component';

describe('ProjectTranslationsComponent', () => {
  let component: ProjectTranslationsComponent;
  let fixture: ComponentFixture<ProjectTranslationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectTranslationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectTranslationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
