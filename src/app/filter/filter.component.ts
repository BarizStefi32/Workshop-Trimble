import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories: Category[] = [
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

  ngOnInit(): void {
  }


}
