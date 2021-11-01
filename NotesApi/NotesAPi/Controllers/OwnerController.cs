using Microsoft.AspNetCore.Mvc;
using NotesAPi.Models;
using NotesAPi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Controllers
{
    public class OwnerController : Controller
    {
        //private static List<Owner> _owners = new List<Owner>()
        //{
        //   new Owner(){  Id =  new Guid("00000000-0000-0000-0000-000000000001"), Name ="Popescu"},
        //   new Owner(){  Id =  new Guid("00000000-0000-0000-0000-000000000002"), Name ="Ionescu"},
        //   new Owner(){  Id =  new Guid("00000000-0000-0000-0000-000000000003"), Name = "Bariz"}

        //};

        readonly IOwnerCollectionService _ownerCollectionService;


        public OwnerController(IOwnerCollectionService ownerCollectionService)
        {
            _ownerCollectionService = ownerCollectionService;
        }


        /// <summary>
        ///     Return all the owners
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Owners")]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                List<Owner> owners = await _ownerCollectionService.GetAll();
                return Ok(owners);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest("Owner cannot be null");
            }
            
        }


        /// <summary>
        ///     Add a new owner
        /// </summary>
        /// <param name="ownerToAdd"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> AddOwner([FromBody] Owner ownerToAdd)
        {
            if (ownerToAdd == null)
            {
                return BadRequest("Owner cannot be null");
            }

            if (await _ownerCollectionService.Create(ownerToAdd))
            {
                return Ok();
            }

            return NoContent();

        }


        /// <summary>
        ///     Delete a specified owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {

            var index = await _ownerCollectionService.Delete(id);
            if (index == false)
            {
                return NotFound();

            }

            return NoContent();

        }


        /// <summary>
        ///     Update an owner
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerToUpdate"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] Owner ownerToUpdate)
        {
            if (ownerToUpdate == null)
            {
                return BadRequest("Note cannot be null");
            }

            var index = await _ownerCollectionService.Update(id, ownerToUpdate);

            if (index == false)
            {
                return NotFound();
            }

            return NoContent();

        }

        /// <summary>
        ///     Return a note find by a specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("{id}", Name = "GetOwnerById")]
        //public async Task<IActionResult> GetOwnerById(Guid id)
        //{

        //    Owner owner = await _ownerCollectionService.Get(id);
        //    if (owner == null)
        //    {
        //        return BadRequest("Note was not found");
        //    }
        //    return Ok(owner);
        //}


    }
}
