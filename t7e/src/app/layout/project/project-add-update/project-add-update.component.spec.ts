import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectAddUpdateComponent } from './project-add-update.component';

describe('ProjectAddUpdateComponent', () => {
  let component: ProjectAddUpdateComponent;
  let fixture: ComponentFixture<ProjectAddUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectAddUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectAddUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
