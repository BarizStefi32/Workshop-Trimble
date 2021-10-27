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
        List<Owner> owners = new List<Owner>()
        {
           new Owner(){ Id = new System.Guid(), Name ="Popescu"},
           new Owner(){ Id = new System.Guid(), Name ="Ionescu"},
           new Owner(){ Id = new System.Guid(), Name = "Bariz"}

        };

        [HttpGet("GetAllOwners")]
        public IActionResult GetAllOwners()
        {
            return Ok(owners);
        }


        [HttpPost("")]
        public IActionResult AddOwner([FromBody] Owner bodyContent)
        {
            owners.Add(bodyContent);
            return Ok(owners);

        }
    }
}
