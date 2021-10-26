import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category';
import { Note } from '../note/note';

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

  constructor() { }

  ngOnInit(): void {
  }

}
