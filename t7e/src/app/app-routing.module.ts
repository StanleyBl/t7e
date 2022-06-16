import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectTranslationsComponent } from './layout/project-translations/project-translations.component';
import { ProjectAddUpdateComponent } from './layout/project/project-add-update/project-add-update.component';
import { ProjectComponent } from './layout/project/project.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/projects',
    pathMatch: 'full'
  },
  {
    path: 'projects',
    component: ProjectComponent
  },
  {
    path: 'projects/edit/:id',
    component: ProjectAddUpdateComponent
  },
  {
    path: 'translations/:id',
    component: ProjectTranslationsComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
