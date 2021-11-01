using Microsoft.AspNetCore.Mvc;
using NotesAPi.Models;
using NotesAPi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {

        //private static List<Notes> _notes = new List<Notes> { new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        //new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        //new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        //new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        //new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        //};

        INoteCollectionService _noteCollectionService;


        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService;
        }


        /// <summary>
        ///     Returns all the notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            List<Notes> notes = await _noteCollectionService.GetAll();
            return Ok(notes);
        }


        /// <summary>
        ///     Add a new note to the list
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNotes([FromBody] Notes note)
        {
            if (note == null)
            {
                return BadRequest("Note cannot be null");
            }

            if (await _noteCollectionService.Create(note))
            {
                return Ok();
            }

            return NoContent();

        }


        /// <summary>
        ///     Return a note find by a specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetNoteById")]
        public async Task<IActionResult> GetNoteById(Guid id)
        {

            Notes note = await _noteCollectionService.Get(id);
            if (note == null)
            {
                return BadRequest("Note was not found");
            }
            return Ok(note);
        }



        /// <summary>
        ///     Delete a note 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
       
            var index = await _noteCollectionService.Delete(id);
            if (index == false)
            {
                return NotFound();

            }

            return NoContent();


        }


        /// <summary>
        ///     Update a note to the list
        /// </summary>
        /// <response code="400">Bad request</response>
        ///  <response code="404">Not found</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] Notes noteToUpdate)
        {
            if (noteToUpdate == null)
            {
                return BadRequest("Note cannot be null");
            }

            var index = await _noteCollectionService.Update(id,noteToUpdate);

            if (index == false)
            {
                return NotFound();
            }

            return NoContent();

        }


        /// <summary>
        ///     Update a note find by note id and owner id
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="ownerId"></param>
        /// <param name="noteToUpdate"></param>
        /// <returns></returns>
        //[HttpPut("{noteId}/owner")]
        //public IActionResult UpdateNoteByAllIds(Guid noteId, Guid ownerId, [FromBody] Notes noteToUpdate)
        //{
        //    if (noteToUpdate == null)
        //    {
        //        return BadRequest("Note cannot be null");
        //    }

        //    int index = _notes.FindIndex(note => note.Id == noteId && note.OwnerId == ownerId);

        //    if (index == -1)
        //    {
        //        return NotFound();
        //    }

        //    noteToUpdate.Id = _notes[index].Id;
        //    _notes[index] = noteToUpdate;

        //    return NoContent();

        //}



        //[HttpPatch("{id}/title")]
        //public IActionResult UpdateTitleNote(Guid id, [FromBody] string title)
        //{
        //    if(string.IsNullOrWhiteSpace(title))
        //    {
        //        return BadRequest("String cannot be null");
        //    }

        //    int index = _notes.FindIndex(note => note.Id == id);
        //    if (index == -1)
        //    {
        //        return NotFound();
        //    }

        //    _notes[index].Title = title;
        //    return Ok(_notes[index]);

        //}





        /// <summary>
        ///         Delete a specified note from a specified owner
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        //[HttpDelete("Delete/{noteId}")]
        //public IActionResult DeleteNoteByAllIds(Guid noteId, Guid ownerId)
        //{

        //    var index = _notes.FindIndex(note => note.Id == noteId && note.OwnerId == ownerId);
        //    if (index == -1)
        //    {
        //        return NotFound();

        //    }

        //    _notes.RemoveAt(index);

        //    return NoContent();


        //}

        /// <summary>
        ///     Delete all the notes from a specified owner
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        //[HttpDelete("Notes/{ownerId}")]
        //public IActionResult DeleteAllNotesByOwnerId( Guid ownerId)
        //{

        //   List<Notes> allNotes = _notes.FindAll(note => note.OwnerId == ownerId);
        //   if (allNotes == null)
        //    {
        //        return NotFound();

        //    }


        //    _notes.RemoveAll(note => allNotes.Contains(note));

        //    return NoContent();


        //}





        /// <summary>
        ///     Return a note owned by a person, find wih a specified owner id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("OwnerId/{id}")]
        //public IActionResult GetByOwnerId(Guid id)
        //{

        //    List<Notes> note = _notes.FindAll(note => note.OwnerId == id);
        //    return Ok(note);
        //}



        /// <summary>
        ///     See headers for url location of resources
        /// </summary>
        /// <param name="note"></param>
        /// <returns>See headers for url location of resources</returns>
        //[HttpPost("Create")]
        //public ActionResult<Notes> Create([FromBody] Notes note)
        //{
        //    if (note == null)
        //    {
        //        return BadRequest("Note was not found");
        //    }

        //    _notes.Add(note);

        //    return CreatedAtRoute("GetNoteById", new { id = note.Id }, note);
        //}






        /// <summary>
        ///    Returns a list of notes
        /// </summary>
        /// <returns></returns>
        /// 

        //  [HttpGet("/mymethod")]  - /mymethod

        //  [HttpGet("mymethod")] - notes/mymethod

        //[HttpGet("{id}")]
        //public IActionResult Get(string id, string id2)
        //{
        //    return Ok($" id:{id}");
        //}

        //[HttpPost("")]
        //public IActionResult Post([FromBody] string bodyContent)
        //{
        //    return Ok(bodyContent);

        // }

        /// <summary>
        ///     Add a new note 
        /// </summary>

        /// <returns></returns>
        //[HttpPost("")]
        //public IActionResult Post([FromBody] Note bodyContent)
        //{
        //    return Ok(bodyContent);

        //}
    }
}
