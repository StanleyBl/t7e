import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Translation } from '../models/translation';
import { TranslationKey } from '../models/translation-key';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  projectBaseUrl = '';

  constructor(private http: HttpClient) {
    this.projectBaseUrl = environment.apiUrl + '/api/v1/translation/'
  }

  getTranslations(projectId: string, searchTerm?: string): Observable<TranslationKey[]> {
    let params = new HttpParams();
    if (searchTerm) {
      params = params.append('searchTerm', searchTerm);
    }
    return this.http.get<TranslationKey[]>(this.projectBaseUrl + projectId, {params});
  } 

  addTranslationKey(key: TranslationKey): Observable<TranslationKey> {
    return this.http.post<TranslationKey>(this.projectBaseUrl + 'key', key);
  }

  updateTranslationKey(key: TranslationKey): Observable<TranslationKey> {
    return this.http.put<TranslationKey>(this.projectBaseUrl + 'key', key);
  }

  addOrUpdateTranslation(model: Translation): Observable<Translation> {
    return this.http.post<Translation>(this.projectBaseUrl + 'translation', model);
  }
}
