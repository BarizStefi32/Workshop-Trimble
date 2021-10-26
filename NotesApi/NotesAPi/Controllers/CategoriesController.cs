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
           new Category(){ Id = 1, Name ="To do"},
           new Category(){ Id = 2, Name ="Doing"},
           new Category(){ Id = 3, Name = "Done"}

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
        public IActionResult GetCategoryById(int id)
        {
           // return Ok($" id:{id}");
            return Ok(categories[id]);
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
        public List<Category> DeleteCategory(int id)
        {
            categories.Remove(categories[id]);
            return categories;

        }

    }
}
