import { HighlightDirectiveText } from './directives/highlight-text.directive';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {MatButtonModule } from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatCardModule } from "@angular/material/card";
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoteComponent } from './note/note.component';
import { ToolsComponent } from './tools/tools.component';
import { AddPipePipe } from './add-pipe.pipe';
import { FilterComponent } from './filter/filter.component';
import { HighlightBackgroundDirective } from './directives/highlight-background.directive';
import { AddHypenPipe } from './pipes/add-hypen.pipe';
import { AddNoteComponent } from './add-note/add-note.component';
import { HomeComponent } from './home/home.component';
import { NoteService } from './services/note.service';
import { RouteParamsComponent } from './route-params/route-params.component';
import { EditNoteComponent } from './edit-note/edit-note.component';


@NgModule({
  declarations: [
    AppComponent,
    NoteComponent,
    ToolsComponent,
    AddPipePipe,
    FilterComponent,
    HighlightDirectiveText,
    HighlightBackgroundDirective,
    AddHypenPipe,
    AddNoteComponent,
    HomeComponent,
    RouteParamsComponent,
    EditNoteComponent

  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [NoteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
