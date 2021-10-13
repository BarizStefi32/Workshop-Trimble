import { FourthlevelModule } from './firstlevel/secondlevel/thirdlevel/fourthlevel/fourthlevel.module';
import { ThirdlevelModule } from './firstlevel/secondlevel/thirdlevel/thirdlevel.module';
import { SecondlevelModule } from './firstlevel/secondlevel/secondlevel.module';
import { FirstlevelModule } from './firstlevel/firstlevel.module';
import { Tema1Module } from './tema1/tema1.module';
import { CommonModule } from '@angular/common';
import { TestModule } from './test/test.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Curs3Component } from './curs3/curs3.component';


@NgModule({
  declarations: [
    AppComponent,
    Curs3Component
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    TestModule,
    Tema1Module,
    FirstlevelModule,
    SecondlevelModule,
    ThirdlevelModule,
    FourthlevelModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
