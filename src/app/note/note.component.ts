import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Note } from './note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  notes: Note[] = [
    {
      id: "Id1",
      title: "First note",
      description: "This is the description for the first note"
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note"
    },
    {
      id: "Id3",
      title: "Third note",
      description: "This is the description for the third note"
    },
    {
      id: "Id4",
      title: "Fourth note",
      description: "This is the description for the fourth note"
    }
  ];

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  showNote(note:any){
    this.router.navigate(['addnote'],{queryParams:{title:note.title, description:note.description}});
  }

}
