using my_book.Data.Models;

namespace my_book.Data
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext dbContext) {
        _context= dbContext;
        }
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title= book.Title,
                Description= book.Description,
                IsRead= book.IsRead == false,    
                DateRead= book.DateRead,    
                DateAdded =DateTime.Now,
                Rate= book.Rate,
                CoverPicture= book.CoverPicture,
                Author= book.Author,
                Genre= book.Genre,

            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
    }
}
