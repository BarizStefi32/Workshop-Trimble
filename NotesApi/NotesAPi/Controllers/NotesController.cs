using Microsoft.AspNetCore.Mvc;
using NotesAPi.Models;
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

        static List<Notes> _notes = new List<Notes> { 
            new Notes
            { 
                Id = new System.Guid(), 
                CategoryId = "1", 
                OwnerId = new System.Guid("833400e7-30cb-494b-887d-139d7a193451"), 
                Title = "First Note", 
                Description = "First Note Description" 
            },
        new Notes 
        { 
            Id = new System.Guid("acfd6456-c7cc-41dc-8b29-54e707e738cd"), 
            CategoryId = "1", 
            OwnerId = new System.Guid("833400e7-30cb-494b-887d-139d7a193451"), 
            Title = "Second Note", 
            Description = "Second Note Description" 
        },
        new Notes 
        { 
            Id = new System.Guid(), 
            CategoryId = "1", 
            OwnerId = new System.Guid(), 
            Title = "Third Note", 
            Description = "Third Note Description" 
        },
        new Notes 
        { 
            Id = new System.Guid(), 
            CategoryId = "1", 
            OwnerId = new System.Guid(), 
            Title = "Fourth Note", 
            Description = "Fourth Note Description" 
        },
        new Notes 
        { 
            Id = new System.Guid(), 
            CategoryId = "1", 
            OwnerId = new System.Guid(), 
            Title = "Fifth Note", 
            Description = "Fifth Note Description" 
        }
        };


        public NotesController() { }


        /// <summary>
        ///     Returns all the notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }


        /// <summary>
        ///     Add a new note to the list
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNotes([FromBody] Notes note)
        {
            if (note == null)
            {
                return BadRequest("Note cannot be null");
            }

            _notes.Add(note);
            return Ok();
        }


        /// <summary>
        ///     Return a note owned by a person, find wih a specified owner id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("OwnerId/{id}")]
        public IActionResult GetByOwnerId(Guid id)
        {

            List<Notes> note = _notes.FindAll(note => note.OwnerId == id);
            return Ok(note);
        }



        /// <summary>
        ///     Return a note find by a specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetNoteById")]
        public IActionResult GetNoteById(Guid id)
        {

            List<Notes> note = _notes.FindAll(note => note.Id == id);
            if(note == null)
            {
                return BadRequest("Note was not found");
            }
            return Ok(note);
        }

        /// <summary>
        ///     See headers for url location of resources
        /// </summary>
        /// <param name="note"></param>
        /// <returns>See headers for url location of resources</returns>
        [HttpPost("Create")]
        public ActionResult<Notes> Create([FromBody] Notes note)
        {
            if (note == null)
            {
                return BadRequest("Note was not found");
            }

            _notes.Add(note);

            return CreatedAtRoute("GetNoteById", new { id = note.Id }, note);
        }






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
