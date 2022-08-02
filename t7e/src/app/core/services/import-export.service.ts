import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ImportFile } from '../models/import-file';

@Injectable({
  providedIn: 'root'
})
export class ImportExportService {

  importExportBaseUrl = '';

  constructor(private http: HttpClient) {
    this.importExportBaseUrl = environment.apiUrl + '/api/v1/ImportExport/'
  }

  uploadFile(model: ImportFile): Observable<any> {
    // const headers = new HttpHeaders().set('Content-Type', 'multipart/form-data');
    // const frmData = new FormData();

    // frmData.append('file', model.file);

    const formData = new FormData();
    for (const key of Object.keys(model)) {
      const value = model[key];
      formData.append(key, value);
    }

    return this.http.post<any>(this.importExportBaseUrl, formData, { reportProgress: true,
      observe: 'events' });
  }
}
