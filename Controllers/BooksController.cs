using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModel;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService booksService;
        public BooksController(BooksService service) 
        {
            this.booksService = service;
        }
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM bookVM)
        {
            booksService.AddBookWithAuthors(bookVM);
            return Ok();
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks= booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id) 
        {
            var book= booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{Id}")]
        public IActionResult UpdateBookById(int Id, [FromBody]BookVM book)
        {
            var updatedBook= booksService.UpdateBookById(Id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{Id}")]
        public IActionResult DeleteBookById(int Id)
        {
            booksService.DeleteBookById(Id);
            return Ok();
        }

        
    }
}
