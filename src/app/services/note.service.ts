import { Injectable } from '@angular/core';
import { Note } from '../note/note';

@Injectable()
export class NoteService {

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
    },
    {
      id: "Id4",
      title: "Fourth note",
      description: "This is the description for the fourth note"
    }
  ];

  constructor() { }

  serviceCall(){
    console.log("Note service was called");
  }

  getNotes(): Note[]{
    return this.notes;

  }

  addNote(id:string, title:string, description:string, category:string): void
  {
     this.notes.push({id:id, title:title, description:description, category:category})

  }
}
