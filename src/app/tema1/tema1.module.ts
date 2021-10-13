import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Paragraph1Component } from './paragraph1/paragraph1.component';
import { Paragraph2Component } from './paragraph2/paragraph2.component';



@NgModule({
  declarations: [Paragraph1Component, Paragraph2Component],
  imports: [
    CommonModule
  ],
  exports: [Paragraph1Component,Paragraph2Component]
})
export class Tema1Module { }
