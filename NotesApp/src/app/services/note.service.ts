import { Category } from './../models/category';
import { Injectable } from '@angular/core';
import { Note } from '../note/note';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { NoteModel } from '../models/noteModel';

@Injectable()
export class NoteService {

  // notes: Note[] = [
  //   {
  //     id: "Id1",
  //     title: "First note",
  //     description: "This is the description for the first note",
  //     categoryId:'1'
  //   },
  //   {
  //     id: "Id2",
  //     title: "Second note",
  //     description: "This is the description for the second note",
  //     categoryId:'2'
  //   },
  //   {
  //     id: "Id3",
  //     title: "Third note",
  //     description: "This is the description for the third note",
  //     categoryId:'3'
  //   },
  //   {
  //     id: "Id4",
  //     title: "Fourth note",
  //     description: "This is the description for the fourth note",
  //     categoryId:'2'
  //   },
  //   {
  //     id: "Id4",
  //     title: "Fourth note",
  //     description: "This is the description for the fourth note",
  //     categoryId:'1'
  //   }
  // ];

  readonly baseUrl= "https://localhost:44379";

  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  constructor(private httpClient: HttpClient) { }

  serviceCall(){
    console.log("Note service was called");
  }


  getNotes():Observable<Note[]>{

    return this.httpClient.get<Note[]>(
      this.baseUrl+`/notes`, this.httpOptions);

  }

  addNote(id:string, title:string, description:string, categoryId:string):  Observable<Note[]>
  {
    const noteModel = new NoteModel(id,title,description,categoryId);

    return this.httpClient.post<Note[]>(
      this.baseUrl + `/notes`, noteModel);
  }

  getFiltredNotes(categoryId:string):Observable<Note[]>{

    return this.httpClient.get<Note[]>(this.baseUrl+`/notes`, this.httpOptions).pipe(map(((notes) => notes.filter((note) => note.categoryId === categoryId))
    ))
  }

  getSearchedNotes(searchTerm:string):Observable<Note[]>{

    return this.httpClient.get<Note[]>(this.baseUrl + `/notes`, this.httpOptions).pipe(map(((notes) => notes.filter(note=>note.title.toLowerCase().includes(searchTerm.toLowerCase()) || note.description.toLowerCase().includes(searchTerm.toLowerCase())))));



  }

  deleteNote(id:string){

    return this.httpClient.delete(this.baseUrl + `/notes/` + id);
  }




}
