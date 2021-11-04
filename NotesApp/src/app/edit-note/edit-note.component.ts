import { ActivatedRoute, Router } from '@angular/router';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { Category } from '../models/category';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss'],
})
export class EditNoteComponent implements OnInit {
  title: string = '';
  description: string = '';
  categories: Category[];
  id: string;

  constructor(
    private noteService: NoteService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.id = params['id'];
    });
  }

  save() {
    //you can pass a new category and owner id
    this.noteService
      .editNote(this.id, this.description, this.title)
      .subscribe(() => this.router.navigateByUrl(''));
  }
}
