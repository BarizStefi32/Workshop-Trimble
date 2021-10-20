import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  categoryId:string;
  termSearch:string;


  constructor() { }

  ngOnInit(): void {
  }

  receiveCategory(categId: string) {
    this.categoryId = categId;
  }

  receiveTermSearch(term: string) {
    this.termSearch = term;
  }


}
