using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModel;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService= authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddBook([FromBody] AuthorVM authorVM)
        {
            _authorService.AddAuthor(authorVM);
            return Ok();
        }
        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBook(int id)
        {
            var response=_authorService.GetAuthorWithBooks(id);
            return Ok(response);
        }

    }
}
