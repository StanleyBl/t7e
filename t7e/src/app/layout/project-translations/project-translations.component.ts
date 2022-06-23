import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { debounceTime, forkJoin } from 'rxjs';
import { NavigationItem } from 'src/app/core/models/navigation';
import { Project } from 'src/app/core/models/project';
import { TranslationKey } from 'src/app/core/models/translation-key';
import { NavigationService } from 'src/app/core/services/internal/navigation.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { TranslationService } from 'src/app/core/services/translation.service';
import { KeyAddEditDialogComponent } from './key-add-edit-dialog/key-add-edit-dialog.component';

@Component({
  selector: 'app-project-translations',
  templateUrl: './project-translations.component.html',
  styleUrls: ['./project-translations.component.scss']
})
export class ProjectTranslationsComponent implements OnInit {

  projectId: string;
  project: Project;
  translationKeys: TranslationKey[] = [];

  isLoading = false;

  searchTerm = new FormControl('');

  constructor(private navigationService: NavigationService,
    private projectService: ProjectService,
    private translationService: TranslationService,
    private dialog: MatDialog,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.projectId = this.route.snapshot.paramMap.get('id');
    this.setNavigationItems();
    this.loadData();

    this.searchTerm.valueChanges.pipe(debounceTime(500)).subscribe(() => {
      this.getTranslations();
    });
  }

  setNavigationItems() {
    const items: NavigationItem[] = [
      {icon: 'add', name: 'Add Key', action: () => this.onAddKey()},
      {icon: 'edit', name: 'Edit Project', route: 'projects/edit/' + this.projectId}
    ];
    this.navigationService.navigation$.next({backAction: '/projects', items: items});
  }

  loadData() {
    this.isLoading = true;
    forkJoin({
      project: this.projectService.getProjectById(this.projectId),
      translations: this.translationService.getTranslations(this.projectId, this.searchTerm.value)
    })
    .subscribe(res => {
      this.project = res.project;
      this.translationKeys = res.translations;
      this.isLoading = false;
    })
  }

  getTranslations() {
    this.translationService.getTranslations(this.projectId, this.searchTerm.value)
    .subscribe(res => {
      this.translationKeys = res;
    })
  }

  onAddKey(key?: TranslationKey) {
    if (!key) {
      key = {projectId: this.projectId};
    }
    this.dialog.open(KeyAddEditDialogComponent, {data: key, width: '500px'})
    .afterClosed().subscribe(res => {
      if (res) {
        this.translationKeys.unshift(res);
      }
    });
  }
}
