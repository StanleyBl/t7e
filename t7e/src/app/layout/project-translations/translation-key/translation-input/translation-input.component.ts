import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { AfterViewInit, Component, ElementRef, Input, NgZone, OnInit, ViewChild } from '@angular/core';
import { Translation } from 'src/app/core/models/translation';
import {take} from 'rxjs/operators';
import { TranslationService } from 'src/app/core/services/translation.service';
import { NotificationService } from 'src/app/core/services/internal/notification.service';

@Component({
  selector: 'app-translation-input',
  templateUrl: './translation-input.component.html',
  styleUrls: ['./translation-input.component.scss']
})
export class TranslationInputComponent implements OnInit {

  @Input() translation: Translation;
  translationCopy: Translation;

  @ViewChild('autosize') autosize: CdkTextareaAutosize;

  constructor(private _ngZone: NgZone,
    private translationService: TranslationService,
    private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.createCopy(this.translation);
  }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1)).subscribe(() => this.autosize.resizeToFitContent(true));
  }

  onSubmit() {
    this.translationService.addOrUpdateTranslation(this.translation)
    .subscribe(res => {
      this.translation = res;
      this.createCopy(res);
      this.notificationService.success('Translation updated');
    }, err => {
      this.notificationService.error('Something went wrong');
    })
  }

  onCancel() {
    this.translation = JSON.parse(JSON.stringify(this.translationCopy));
  }

  private createCopy(translation: Translation) {
    this.translationCopy = JSON.parse(JSON.stringify(translation));
  }
}
