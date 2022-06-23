import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslationKey } from 'src/app/core/models/translation-key';
import { NotificationService } from 'src/app/core/services/internal/notification.service';
import { TranslationService } from 'src/app/core/services/translation.service';

@Component({
  selector: 'app-key-add-edit-dialog',
  templateUrl: './key-add-edit-dialog.component.html',
  styleUrls: ['./key-add-edit-dialog.component.scss']
})
export class KeyAddEditDialogComponent implements OnInit {

  form = this.fb.group({
    id: [],
    key: ['', [Validators.required]],
    description: [''],
    projectId: ['']
  });

  newKey = true;

  constructor(private fb: FormBuilder,
    private translationService: TranslationService,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<KeyAddEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TranslationKey) { }

  ngOnInit(): void {
    this.newKey = !this.data.id;
    if (this.newKey) {
      this.data.id = '00000000-0000-0000-0000-000000000000';
    }
    this.form.patchValue(this.data);
  }

  onSubmit() {
    if (this.newKey) {
      this.translationService.addTranslationKey(this.form.value)
      .subscribe(res => {
        this.dialogRef.close(res);
        this.notificationService.success('Key added');
      }, err => {
        this.notificationService.error('Something went wrong');
      })
    } else {
      this.translationService.updateTranslationKey(this.form.value)
      .subscribe(res => {
        this.dialogRef.close(res);
        this.notificationService.success('Key updated');
      }, err => {
        this.notificationService.error('Something went wrong');
      })
    }
  }
}
