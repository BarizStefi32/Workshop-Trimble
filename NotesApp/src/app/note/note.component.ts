import { Observable } from 'rxjs';
import { NoteService } from './../services/note.service';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Note } from './note';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit, OnChanges {


  notes: Note[];
  @Input() selectedCategoryId: string;
  @Input() selectedTerm: string;
  @Output() emitUpdateNote = new EventEmitter<string>();

  constructor(private router:Router, private noteService:NoteService) { }

  ngOnInit(): void {
    this.noteService.serviceCall();

  //  this.noteService.getNotes().subscribe((result) =>{

   // this.notes = result;

   // })

   this.getNotes();


  }

  showNote(note:any){
    this.router.navigate(['addnote'],{queryParams:{title:note.title, description:note.description}});
  }

  ngOnChanges(): void {
    if (this.selectedCategoryId) {
       this.noteService.getFiltredNotes(this.selectedCategoryId).subscribe((result) =>{
         this.notes = result;
       })


    }

    if (this.selectedTerm) {
      this.noteService.getSearchedNotes(this.selectedTerm).subscribe((result) =>{
        this.notes = result;
      })
    }
  }


  deleteNote(id:string) {

    this.noteService.deleteNote(id).subscribe(()=>this.getNotes());
  }

  getNotes(){
     this.noteService.getNotes().subscribe((result)=>{
        this.notes = result;
         });
      }




}
