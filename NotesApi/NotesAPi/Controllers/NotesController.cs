using Microsoft.AspNetCore.Mvc;
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
        public NotesController() { }

        /// <summary>
        ///    Returns a list of notes
        /// </summary>
        /// <returns></returns>
        /// 
       
        //  [HttpGet("/mymethod")]  - /mymethod

        //  [HttpGet("mymethod")] - notes/mymethod

        [HttpGet("{id}")]
        public IActionResult Get(string id, string id2)
        {
            return Ok($" id:{id}");
        }

        //[HttpPost("")]
        //public IActionResult Post([FromBody] string bodyContent)
        //{
        //    return Ok(bodyContent);

       // }

        /// <summary>
        ///     Add a new note 
        /// </summary>
        /// <param name="bodyContent"></param>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult Post([FromBody] Note bodyContent)
        {
            return Ok(bodyContent);

        }
    }
}
