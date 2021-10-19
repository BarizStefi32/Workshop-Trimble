import { CategoryService } from './../services/category.service';
import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories: Category[];

  constructor(private _categoryService:CategoryService) { }

  ngOnInit(): void {

    this.categories= this._categoryService.getCategories();

  }


}
