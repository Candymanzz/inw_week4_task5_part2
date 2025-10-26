using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task.DTOs;
using Task.Interfaces;
using Task.Models;

namespace Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsService authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthorsAsync()
        {
            List<Author> authors = await authorsService.GetAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorAsync(Guid id)
        {

            Author? author = await authorsService.GetAuthorAsync(id);
            if (author is null)
            {
                return NotFound(new { error = "Author not found" });
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthorAsync([FromBody] Author author)
        {
            await authorsService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthorAsync), new { id = author.Id }, author);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAuthorAsync(Guid id)
        {
            await authorsService.RemoveAuthorAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAuthorAsync([FromBody] Author author)
        {
            await authorsService.UpdateAuthorAsync(author);
            return NoContent();
        }

        [HttpGet("with-book-counts")]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthorsWithBookCountsAsync()
        {
            var authors = await authorsService.GetAuthorsWithBookCountsAsync();
            return Ok(authors);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<AuthorDto>>> FindAuthorsByNameAsync([FromQuery] string name)
        {
            var authors = await authorsService.FindAuthorsByNameAsync(name);
            return Ok(authors);
        }
    }
}
