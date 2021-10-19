import { NoteService } from './../services/note.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Note } from './note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  notes: Note[];

  constructor(private router:Router, private noteService:NoteService) { }

  ngOnInit(): void {
    this.noteService.serviceCall();
    this.notes = this.noteService.getNotes();

  }

  showNote(note:any){
    this.router.navigate(['addnote'],{queryParams:{title:note.title, description:note.description}});
  }

}
