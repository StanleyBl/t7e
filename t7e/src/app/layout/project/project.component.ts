import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { NavigationItem } from 'src/app/core/models/navigation';
import { ProjectInfo } from 'src/app/core/models/project';
import { NavigationService } from 'src/app/core/services/internal/navigation.service';
import { ProjectService } from 'src/app/core/services/project.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent implements OnInit {

  projects$: Observable<ProjectInfo[]>;

  constructor(private projectService: ProjectService,
    private navigationService: NavigationService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.load();
    this.setNavigationItems();
  }

  setNavigationItems() {
    const items: NavigationItem[] = [
      {icon: 'add', name: 'Add new Project', route: 'projects/edit/add'}
    ];
    this.navigationService.navigation$.next({items: items});
  }

  load() {
    this.projects$ = this.projectService.getProjectInfoList();
  }
}
