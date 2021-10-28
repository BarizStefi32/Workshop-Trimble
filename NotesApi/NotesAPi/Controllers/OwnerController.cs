using Microsoft.AspNetCore.Mvc;
using NotesAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Controllers
{
    public class OwnerController : Controller
    {
        private static List<Owner> _owners = new List<Owner>()
        {
           new Owner(){  Id =  new Guid("00000000-0000-0000-0000-000000000001"), Name ="Popescu"},
           new Owner(){  Id =  new Guid("00000000-0000-0000-0000-000000000002"), Name ="Ionescu"},
           new Owner(){  Id =  new Guid("00000000-0000-0000-0000-000000000003"), Name = "Bariz"}

        };

        public OwnerController() { }

        /// <summary>
        ///     Return all the owners
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Owners")]
        public IActionResult GetAllOwners()
        {
            return Ok(_owners);
        }


        /// <summary>
        ///     Add a new owner
        /// </summary>
        /// <param name="bodyContent"></param>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult AddOwner([FromBody] Owner bodyContent)
        {
            _owners.Add(bodyContent);
            return Ok(_owners);

        }


        /// <summary>
        ///     Delete a specified owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {

            var index = _owners.FindIndex(owner => owner.Id == id);

         
            if (index == -1)
            {
                return NotFound();

            }

            _owners.RemoveAt(index);

            return NoContent();

        }


        /// <summary>
        ///     Update an owner
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerToUpdate"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner ownerToUpdate)
        {
            if (ownerToUpdate == null)
            {
                return BadRequest("Note cannot be null");
            }

            int index = _owners.FindIndex(owner => owner.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            ownerToUpdate.Id = _owners[index].Id;
            _owners[index] = ownerToUpdate;

            return NoContent();

        }


    }
}
