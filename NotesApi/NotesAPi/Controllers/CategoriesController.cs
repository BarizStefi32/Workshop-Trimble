using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        List<Category> categories = new List<Category>()
        {
           new Category(){ Id = new System.Guid("bd8686e6-406f-4a4f-81f9-08b005ece418"), Name ="To do"},
           new Category(){ Id = new System.Guid("02b1fb2e-ecd4-491e-bfc2-3b20410caf0d"), Name ="Doing"},
           new Category(){ Id = new System.Guid(), Name = "Done"}

        };


        /// <summary>
        ///     Returns the full list of categories
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        /// 
        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok(categories);
        }


        /// <summary>
        ///     Returns only a category selected by the param id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        /// 

       // [HttpGet("GetCategoryById/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
           // return Ok(categories.IndexOf(id));

            Category item = categories.Find(category => category.Id == id);
            if (item == null)
            {
                return BadRequest("Did not find the category with the id specified");
            }

            return Ok(item);


        }

        /// <summary>
        ///     Add a new category to the list
        /// </summary>
        /// <param name="bodyContent"></param>
        /// <response code="201">Created</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult AddCategory([FromBody] Category bodyContent)
        {
            categories.Add(bodyContent);
            return Ok(categories);

        }

        /// <summary>
        ///     Delete a category selected by the param id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {

            Category item = categories.Find(category => category.Id == id);
            if ( item == null)
            {
                return BadRequest("Category was not found!");
   
            }

            categories.RemoveAt(categories.IndexOf(item));
            return NoContent();


        }



    }
}
