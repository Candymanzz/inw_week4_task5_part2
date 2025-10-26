using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Author>> GetAuthors()
        {
            List<Author> authors = authorsService.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(Guid id)
        {
            try
            {
                Author? author = authorsService.GetAuthor(id);
                if (author is null)
                {
                    return NotFound(new { error = "Author not found" });
                }

                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult AddAuthor([FromBody] Author author)
        {
            try
            {
                authorsService.AddAuthor(author);
                return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAuthor(Guid id)
        {
            try
            {
                authorsService.RemoveAuthor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(Guid id, [FromBody] Author author)
        {
            try
            {
                authorsService.UpdateAuthor(id, author);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message});
            }
        }
    }
}
