import { AppRoutingModule } from './../app-routing.module';
import { MatInputModule } from '@angular/material/input';
import { Component, OnInit } from '@angular/core';

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

  constructor() { }

  ngOnInit(): void {
  }

  ButtonClick(color: string): void{
    // alert("Button Click");
    // this.title = "Something else";
    // this.textColor = "green";
    this.color = color;

  }
}
