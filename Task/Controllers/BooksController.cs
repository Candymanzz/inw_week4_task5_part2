using Microsoft.AspNetCore.Mvc;
using Task.Interfaces;
using Task.Models;
using Task.Services;

namespace Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            List<Book> books = booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(Guid id)
        {
            try
            {
                Book? book = booksService.GetBook(id);
                if (book is null)
                {
                    return NotFound(new { error = "Book not found" });
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book book)
        {
            try
            {
                booksService.AddBook(book);
                return CreatedAtAction(nameof(AddBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveBook(Guid id)
        {
            try
            {
                booksService.RemoveBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, [FromBody] Book book)
        {
            try
            {
                booksService.UpdateBook(id, book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
