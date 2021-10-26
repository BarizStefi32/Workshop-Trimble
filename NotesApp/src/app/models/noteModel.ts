import { Note } from './../note/note';
export class NoteModel implements Note {
  id: string;
  title: string;
  description: string;
  categoryId: string;

  constructor(id:string, title:string, description:string, categoryId:string)
  {
    this.id = id;
    this.title = title;
    this.description = description;
    this.categoryId = categoryId;

  }

}
