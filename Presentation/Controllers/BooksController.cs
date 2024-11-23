using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.NotFoundException;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;


        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookServices.GetAllBooks(false);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {

            var book = _manager.BookServices.GetOneBookById(id, false);
            
            
            return Ok(book);
        }


        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            if (book is null)
            {
                return BadRequest(); ///404
            }
            _manager.BookServices.CreateOneBook(book);
            return StatusCode(201, book);

        }



        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            if (book is null)
            {
                return BadRequest();
            }
            _manager.BookServices.UpdateOneBook(id, book, true);
            return NoContent();//204

        }




        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = _manager.BookServices.GetOneBookById(id, false);
            if (entity is null) return NotFound(new
            {
                statusCode = 404,
                message = $"Book with id:{id} could not found!"
            }); ///404 olmayan bir kaynak
            _manager.BookServices.DeleteOneBook(id, false);
            return NoContent();
        }
    }
}
