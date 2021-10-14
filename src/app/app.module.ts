import { FourthlevelModule } from './firstlevel/secondlevel/thirdlevel/fourthlevel/fourthlevel.module';
import { ThirdlevelModule } from './firstlevel/secondlevel/thirdlevel/thirdlevel.module';
import { SecondlevelModule } from './firstlevel/secondlevel/secondlevel.module';
import { FirstlevelModule } from './firstlevel/firstlevel.module';
import { Tema1Module } from './tema1/tema1.module';
import { CommonModule } from '@angular/common';
import { TestModule } from './test/test.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {MatButtonModule } from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Curs3Component } from './curs3/curs3.component';
import { NoteComponent } from './note/note.component';
import { ToolsComponent } from './tools/tools.component';


@NgModule({
  declarations: [
    AppComponent,
    Curs3Component,
    NoteComponent,
    ToolsComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    TestModule,
    Tema1Module,
    FirstlevelModule,
    SecondlevelModule,
    ThirdlevelModule,
    FourthlevelModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
