using my_book.Data.Models;
using my_book.Data.ViewModel;

namespace my_book.Data.Services
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext appDbContext)
        {
            _context=appDbContext;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        public AuthorWithBookVM GetAuthorWithBooks(int authorId)
        {
            var _author= _context.Authors.Where(n=>n.Id==authorId).Select(n=>new AuthorWithBookVM()
            {
                FullName = n.FullName,
                BookTitles= n.Book_Authors.Select(n=>n.Book.Title).ToList(),
            }).FirstOrDefault();
            return _author;
        }
    }
}
