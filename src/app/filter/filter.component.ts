import { CategoryService } from './../services/category.service';
import { Component, OnInit, Output } from '@angular/core';
import { Category } from '../models/category';
import { EventEmitter } from '@angular/core';
import { Note } from '../note/note';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories: Category[];
  notes: Note[];
  titleSearch: string ="";
  @Output() emitSelectedFilter = new EventEmitter<string>();
  @Output() emitSearchFunction = new EventEmitter<string>();

  constructor(private _categoryService:CategoryService) { }

  ngOnInit(): void {

    this.categories= this._categoryService.getCategories();

  }

  selectFilter(categoryId:string){
    this.emitSelectedFilter.emit(categoryId);
  }

  searchNotes(){
    this.emitSearchFunction.emit(this.titleSearch);
  }

}
