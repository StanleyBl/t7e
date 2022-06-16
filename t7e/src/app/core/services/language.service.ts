import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Language } from '../models/language';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {

  projectBaseUrl = '';

  constructor(private http: HttpClient) {
    this.projectBaseUrl = environment.apiUrl + '/api/v1/language/'
  }

  getLanguages(): Observable<Language[]> {
    return this.http.get<Language[]>(this.projectBaseUrl);
  }
}
