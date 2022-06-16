import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslationKey } from 'src/app/core/models/translation-key';

@Component({
  selector: 'app-key-add-edit-dialog',
  templateUrl: './key-add-edit-dialog.component.html',
  styleUrls: ['./key-add-edit-dialog.component.scss']
})
export class KeyAddEditDialogComponent implements OnInit {

  form = this.fb.group({
    id: [],
    key: ['', [Validators.required]],
    description: ['']
  });

  constructor(private fb: FormBuilder,
    public dialogRef: MatDialogRef<KeyAddEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TranslationKey) { }

  ngOnInit(): void {
    console.log(this.data)
  }

  onSubmit() {

  }
}
