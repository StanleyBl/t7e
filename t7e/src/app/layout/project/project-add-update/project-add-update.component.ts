import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, of } from 'rxjs';
import { Language } from 'src/app/core/models/language';
import { Project } from 'src/app/core/models/project';
import { NavigationService } from 'src/app/core/services/internal/navigation.service';
import { LanguageService } from 'src/app/core/services/language.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { LanguageAddEditDialogComponent } from './language-add-edit-dialog/language-add-edit-dialog.component';

@Component({
  selector: 'app-project-add-update',
  templateUrl: './project-add-update.component.html',
  styleUrls: ['./project-add-update.component.scss']
})
export class ProjectAddUpdateComponent implements OnInit {

  projectId: string;
  project: Project;
  languages: Language[] = [];
  newProject = true;
  backAction: string;

  projectForm = this.fb.group({
    id: [],
    name: ['', [Validators.required]],
    description: [''],
    logoUrl: [''],
  });

  constructor(private fb: FormBuilder,
    private navigationService: NavigationService,
    private route: ActivatedRoute,
    private router: Router,
    private dialog: MatDialog,
    private languageService: LanguageService,
    private projectService: ProjectService) { }

  ngOnInit(): void {
    this.projectId = this.route.snapshot.paramMap.get('id');
    this.newProject = this.projectId === 'add';

    this.setNavigationItems();
    this.loadData();
  }

  setNavigationItems() {
    this.backAction = this.newProject ? '/projects' : '/translations/' + this.projectId;
    this.navigationService.navigation$.next({backAction: this.backAction, items: []});
  }

  loadData() {
    forkJoin({
      languages: this.languageService.getLanguages(),
      project: this.newProject ? of(null) : this.projectService.getProjectById(this.projectId)
    })
    .subscribe(res => {
      this.languages = res.languages;

      if (res.project) {
        this.project = res.project;
        this.projectForm.patchValue(res.project);
      } else {
        this.project = {};
      }
    });
  }

  onAddLanguage() {
    this.dialog.open(LanguageAddEditDialogComponent, {
      data: { languages: this.languages, selectedLanguages: this.project.availableLanguages},
      width: '500px'
    })
    .afterClosed()
    .subscribe(res => {
      if (res) {
        this.project.availableLanguages = res;
      }
    })
  }

  onSubmit() {
    this.project.id = this.projectForm.controls['id']?.value;
    this.project.name = this.projectForm.controls['name'].value;
    this.project.description = this.projectForm.controls['description'].value;
    this.project.logoUrl = this.projectForm.controls['logoUrl'].value;

    this.projectService.addOrUpdateProject(this.project)
    .subscribe(res => {
      this.router.navigate([this.backAction]);
    });
  }
}
