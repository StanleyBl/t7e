import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TranslationKey } from 'src/app/core/models/translation-key';
import { NotificationService } from 'src/app/core/services/internal/notification.service';
import { KeyAddEditDialogComponent } from '../key-add-edit-dialog/key-add-edit-dialog.component';

@Component({
  selector: 'app-translation-key',
  templateUrl: './translation-key.component.html',
  styleUrls: ['./translation-key.component.scss']
})
export class TranslationKeyComponent implements OnInit {

  @Input() key: TranslationKey;

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  onKeyClick() {
    this.dialog.open(KeyAddEditDialogComponent, {data: this.key, width: '500px'})
    .afterClosed().subscribe((res: TranslationKey) => {
      if (res) {
        this.key.key = res.key;
        this.key.description = res.description;
      }
    });
  }
}
