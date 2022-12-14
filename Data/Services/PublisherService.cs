using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_book.Data.Models;
using my_book.Data.ViewModel;

namespace my_book.Data.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            { 
                Name=publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData= _context.Publishers.Where(n=>n.Id==publisherId).
                Select(n=>new PublisherWithBooksAndAuthorsVM()
                {
                    Name=n.Name,
                    BookAuthors=n.Books.Select(n=>new BookAuthorVM()
                    {
                        BookName=n.Title,
                        BookAuthors=n.Book_Authors.Select(n=>n.Author.FullName).ToList()
                    }).ToList()
                    
                }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher=_context.Publishers.Where(n=>n.Id==id).FirstOrDefault();
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
