import { Category } from './../models/category';
import { Injectable } from '@angular/core';
import { Note } from '../note/note';

@Injectable()
export class NoteService {

  notes: Note[] = [
    {
      id: "Id1",
      title: "First note",
      description: "This is the description for the first note",
      categoryId:'1'
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note",
      categoryId:'2'
    },
    {
      id: "Id3",
      title: "Third note",
      description: "This is the description for the third note",
      categoryId:'3'
    },
    {
      id: "Id4",
      title: "Fourth note",
      description: "This is the description for the fourth note",
      categoryId:'2'
    },
    {
      id: "Id4",
      title: "Fourth note",
      description: "This is the description for the fourth note",
      categoryId:'1'
    }
  ];

  constructor() { }

  serviceCall(){
    console.log("Note service was called");
  }

  getNotes(): Note[]{
    return this.notes;

  }

  addNote(id:string, title:string, description:string, categoryId:string): void
  {
     this.notes.push({id:id, title:title, description:description, categoryId:categoryId})

  }

  getFiltredNotes(categoryId:string):Note[]{
    return this.notes.filter(note=>note.categoryId === categoryId);
  }

  getSearchedNotes(searchTerm:string):Note[]{

    return this.notes.filter(note=>note.title.toLowerCase().includes(searchTerm.toLowerCase()) || note.description.toLowerCase().includes(searchTerm.toLowerCase()));

  }

}
