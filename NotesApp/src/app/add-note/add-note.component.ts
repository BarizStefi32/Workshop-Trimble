import { CategoryService } from './../services/category.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Note } from '../note/note';
import { NoteService } from '../services/note.service';
import { Location } from '@angular/common';
import { Category } from '../models/category';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

     private categoryId:string="";

     title:string ="";
     description:string="";
     notes:Note[];
     categories:Category[];


  constructor(private _activatedRoute: ActivatedRoute, private _noteService: NoteService,private _categoryService: CategoryService,private _location: Location) { }

  ngOnInit(): void {

    // this.notes=this._noteService.getNotes();
    this.categories = this._categoryService.getCategories();

    // this._activatedRoute.queryParams.subscribe(params => {
    //      this.title= params["title"];
    //      this.description =params["description"];
    //  })
  }

  addNote():void {
    this._noteService.addNote(this.newGuid(),this.title,this.description,this.categoryId).subscribe((result) =>{
      this.notes.push(...result);
    })

      this._location.back();
  }

  onChange(event){

    this.categoryId = event.value;

  }

  checkInputs(){
    if(this.title !== "" && this.description !== "" && this.categoryId !== ""){

      return false;
    }

    return true;

  }

  private newGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(
      /[xy]/g,
      function (c) {
        var r = (Math.random() * 16) | 0,
          v = c == 'x' ? r : (r & 0x3) | 0x8;
        return v.toString(16);
      }
    );
  }

}
