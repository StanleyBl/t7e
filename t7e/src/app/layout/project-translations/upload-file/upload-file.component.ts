import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ImportFile } from 'src/app/core/models/import-file';
import { Project } from 'src/app/core/models/project';
import { ImportExportService } from 'src/app/core/services/import-export.service';
import { NotificationService } from 'src/app/core/services/internal/notification.service';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})
export class UploadFileComponent implements OnInit {

  knownTypes = ['.resx', '.json'];

  @ViewChild('fileInput') fileInput: ElementRef;
  fileAttr = 'Choose File';

  model: ImportFile = {};

  constructor(
    private importService: ImportExportService,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<UploadFileComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Project) { }

  ngOnInit(): void {
    this.model.projectId = this.data.id;
  }

  uploadFileEvt(file: any) {
    const uploadFile = file.target.files[0];
    this.model.file = undefined;

    if (!uploadFile) {
      this.fileAttr = 'Choose File';
      return;
    }

    if(!this.knownTypes.some(x => uploadFile.name.endsWith(x))) {
      this.notificationService.error('Unknown file type');
      return;
    }

    this.fileAttr += uploadFile.name;
    let reader = new FileReader();
    reader.onload = (e: any) => {
    };
    reader.readAsDataURL(file.target.files[0]);
    this.fileInput.nativeElement.value = '';
    this.model.file = uploadFile;
  }

  isValid(): boolean {
    return !!this.model.languageId && !!this.model.file;
  }

  onSubmit() {
    this.importService.uploadFile(this.model)
    .subscribe(res => {

    });
  }
}
