import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { NavigationItem } from 'src/app/core/models/navigation';
import { Project } from 'src/app/core/models/project';
import { TranslationKey } from 'src/app/core/models/translation-key';
import { NavigationService } from 'src/app/core/services/internal/navigation.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { KeyAddEditDialogComponent } from './key-add-edit-dialog/key-add-edit-dialog.component';

@Component({
  selector: 'app-project-translations',
  templateUrl: './project-translations.component.html',
  styleUrls: ['./project-translations.component.scss']
})
export class ProjectTranslationsComponent implements OnInit {

  projectId: string;
  project: Project;

  constructor(private navigationService: NavigationService,
    private projectService: ProjectService,
    private dialog: MatDialog,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.projectId = this.route.snapshot.paramMap.get('id');
    this.setNavigationItems();
    this.loadData();
  }

  setNavigationItems() {
    const items: NavigationItem[] = [
      {icon: 'add', name: 'Add Key', action: () => this.onAddKey()},
      {icon: 'edit', name: 'Edit Project', route: 'projects/edit/' + this.projectId}
    ];
    this.navigationService.navigation$.next({backAction: '/projects', items: items});
  }

  loadData() {
    forkJoin({
      project: this.projectService.getProjectById(this.projectId)
    })
    .subscribe(res => {
      this.project = res.project;
    })
  }

  onAddKey(key?: TranslationKey) {
    this.dialog.open(KeyAddEditDialogComponent, {data: key, width: '500px'});
  }
}
