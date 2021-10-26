import { NoteComponent } from './note/note.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddNoteComponent } from './add-note/add-note.component';
import { RouteParamsComponent } from './route-params/route-params.component';
import { EditNoteComponent } from './edit-note/edit-note.component';

const appRoutes:Routes=[
  { path: "", component: HomeComponent, pathMatch:"full"},
  { path:"addnote", component: AddNoteComponent},
  { path:"editnote", component: EditNoteComponent},
  { path:"routeparams/:id", component: RouteParamsComponent},
  { path: '**', redirectTo: ''}
]


@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
