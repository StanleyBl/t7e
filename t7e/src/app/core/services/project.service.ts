import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Project } from '../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  projectBaseUrl = '';

  constructor(private http: HttpClient) {
    this.projectBaseUrl = environment.apiUrl + '/api/v1/project/'
  }

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.projectBaseUrl);
  }

  getProjectById(id: string): Observable<Project> {
    return this.http.get<Project>(this.projectBaseUrl + id);
  }

  addOrUpdateProject(project: Project): Observable<any> {
    return this.http.put<Project>(this.projectBaseUrl, project);
  }

  deleteProject(id: string): Observable<any> {
    return this.http.delete(this.projectBaseUrl + id);
  }
}
