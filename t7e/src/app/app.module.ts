import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {MatDialogModule} from '@angular/material/dialog';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSelectModule} from '@angular/material/select';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatTabsModule} from '@angular/material/tabs';
import {MatRadioModule} from '@angular/material/radio';
import {MatSliderModule} from '@angular/material/slider';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectComponent } from './layout/project/project.component';
import { ProjectAddUpdateComponent } from './layout/project/project-add-update/project-add-update.component';
import { NavigationComponent } from './layout/navigation/navigation.component';
import { ProjectTranslationsComponent } from './layout/project-translations/project-translations.component';
import { LanguageAddEditDialogComponent } from './layout/project/project-add-update/language-add-edit-dialog/language-add-edit-dialog.component';
import { KeyAddEditDialogComponent } from './layout/project-translations/key-add-edit-dialog/key-add-edit-dialog.component';
import { TranslationKeyComponent } from './layout/project-translations/translation-key/translation-key.component';
import { TranslationInputComponent } from './layout/project-translations/translation-key/translation-input/translation-input.component';

@NgModule({
  declarations: [
    AppComponent,
    ProjectComponent,
    ProjectAddUpdateComponent,
    NavigationComponent,
    ProjectTranslationsComponent,
    LanguageAddEditDialogComponent,
    KeyAddEditDialogComponent,
    TranslationKeyComponent,
    TranslationInputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatToolbarModule,
    MatProgressBarModule,
    MatIconModule,
    MatMenuModule,
    MatDialogModule,
    MatCheckboxModule,
    MatSelectModule,
    DragDropModule,
    MatDatepickerModule,
    MatExpansionModule,
    MatAutocompleteModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatTabsModule,
    MatRadioModule,
    MatSliderModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
