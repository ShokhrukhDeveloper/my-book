using my_book.Data.Models;
using my_book.Data.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace my_book.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead ?? false,
                DateRead = book.DateRead,
                DateAdded = DateTime.Now,
                Rate = book.Rate,
                CoverPicture = book.CoverPicture,
                Genre = book.Genre,
                PublisherId= book.PublisherId,

            };
            _context.Books.Add(_book);
            _context.SaveChanges();
            foreach (var Id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = Id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() 
        {
            var books = _context.Books.ToList();
            return books;
        }

        public BookWithAuthorsVM? GetBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(na=>na.Id==bookId).Select(book => new BookWithAuthorsVM()
            {

                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                CoverPicture = book.CoverPicture,
                Genre = book.Genre,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }
        public Book? UpdateBookById(int Id, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(b=>b.Id==Id);
            if (_book is not null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead ?? false;
                _book.DateRead = book.DateRead;
                _book.DateAdded = DateTime.Now;
                _book.Rate = book.Rate;
                _book.CoverPicture = book.CoverPicture;
                _book.Genre = book.Genre;
                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if(_book is not null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
