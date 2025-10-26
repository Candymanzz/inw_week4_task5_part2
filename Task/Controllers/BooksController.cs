using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task.DTOs;
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
        public async Task<ActionResult<List<Book>>> GetBooksAsync()
        {
            List<Book> books = await booksService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookAsync(Guid id)
        {
            Book? book = await booksService.GetBookAsync(id);
            if (book is null)
            {
                return NotFound(new { error = "Book not found" });
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> AddBookAsync([FromBody] Book book)
        {
            await booksService.AddBookAsync(book);
            return CreatedAtAction(nameof(AddBookAsync), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveBookAsync(Guid id)
        {
            await booksService.RemoveBookAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookAsync([FromBody] Book book)
        {
            await booksService.UpdateBookAsync(book);
            return NoContent();
        }

        [HttpGet("after/{year}")]
        public async Task<ActionResult<List<BookDto>>> GetBooksPublishedAfterAsync(int year)
        {
            var books = await booksService.GetBooksPublishedAfterAsync(year);
            return Ok(books);
        }
    }
}
