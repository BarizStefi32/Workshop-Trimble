import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from '../models/category';
import { Note } from '../note/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss']
})
export class EditNoteComponent implements OnInit {


     title:string ="";
     description:string="";
     notes:Note[];
     categories:Category[];

     @Input() noteId: string;


  constructor(private noteService : NoteService) { }

  ngOnInit(): void {
  }


  editNote(id:string){

    // this.router.navigateByUrl('/editnote/{id}');
     this.noteService.editNote(id).subscribe((result)=>{
        let noteToEdit = this.notes.find(note => note.id == result.id);
        noteToEdit = result;
       });

    }

}
