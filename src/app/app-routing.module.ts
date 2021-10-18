import { NoteComponent } from './note/note.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddNoteComponent } from './add-note/add-note.component';

const appRoutes:Routes=[
  { path: "", component: HomeComponent, pathMatch:"full"},
  { path:"addnote ", component: AddNoteComponent},
  { path: '**', redirectTo: ''}
]


@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
