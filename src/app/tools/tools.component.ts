import { AppRoutingModule } from './../app-routing.module';
import { MatInputModule } from '@angular/material/input';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  title: string = "Something";
  textColor : string = "red";
  noteContent : string = "";
  color: string = 'black';
  currentDate = Date.now();
  listOfStrings: string[] = ['Ana are mere', ' Mihai are pere', 'Stefania are ciocolata', 'Raluca are biscuiti'];
  listOfDate: Date[] = [new Date('December 17, 1995 12:06:00'),
                       new Date('January 23, 2021 22:24:00'),
                       new Date('March 10, 2019 14:10:00'),
                       new Date('April 25, 2009 13:20:00'),
                       new Date('February 02, 2011 17:40:00')
                      ];

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  ButtonClick(color: string): void{
    // alert("Button Click");
    // this.title = "Something else";
    // this.textColor = "green";
    this.color = color;

  }

  addNote():void{
    // const result = this.router.navigateByUrl("../addnote");
    // console.log(Promise.resolve(result));
  this.router.navigateByUrl('/addnote');
  }
}
