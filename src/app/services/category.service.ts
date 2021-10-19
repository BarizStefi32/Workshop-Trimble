import { Category } from './../models/category';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  categories:Category[] =
  [
    {id:'1',
    name:'To do'
  },

    {id:'2',
    name:'Done'
  },

    {id:'3',
    name:'Doing'
  }
  ]

  constructor() { }

  getCategories(): Category[]{
    return this.categories;
  }


}
