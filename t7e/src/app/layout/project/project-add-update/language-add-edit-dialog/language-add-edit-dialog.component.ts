import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Language } from 'src/app/core/models/language';

@Component({
  selector: 'app-language-add-edit-dialog',
  templateUrl: './language-add-edit-dialog.component.html',
  styleUrls: ['./language-add-edit-dialog.component.scss']
})
export class LanguageAddEditDialogComponent implements OnInit {

  selectedLanguages: Language[] = [];

  constructor(public dialogRef: MatDialogRef<LanguageAddEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {languages: Language[], selectedLanguages: Language[]}) { }

  ngOnInit(): void {
    this.selectedLanguages = JSON.parse(JSON.stringify(this.data?.selectedLanguages || []));
  }

  isChecked(id: string) {
    return this.selectedLanguages.map(x => x.id).includes(id);
  }

  onChange(lang: Language, checked: boolean) {
    if (checked) {
      if (!this.isChecked(lang.id)) {
        this.selectedLanguages.push(lang);
      }
    } else {
      this.selectedLanguages = this.selectedLanguages.filter(x => x.id != lang.id);
    }
  }

  onSubmit() {
    this.dialogRef.close(this.selectedLanguages);
  }
}
