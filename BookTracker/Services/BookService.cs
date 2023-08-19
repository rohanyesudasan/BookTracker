using BookTracker.Models;

namespace BookTracker.Services
{
    public class BookService : IBookService
    {
        public BookTrackerContext _DbContext { get; set; }
        public BookService(BookTrackerContext bookTrackerContext)
        {
            _DbContext = bookTrackerContext;
        }
        public Book AddBook(Book book)
        {
            _DbContext.Add(book);
            _DbContext.SaveChanges();
            return book;
        }

        public void DeleteBook(Book book)
        {
            _DbContext.Remove(book);
            _DbContext.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _DbContext.Books.ToList();
        }

        public Book UpdateBook(Book book)
        {
            _DbContext.Update(book);
            _DbContext.SaveChanges();
            return book;
        }
    }

    public interface IBookService
    {
        public Book AddBook(Book book);
        public Book UpdateBook(Book book);
        public void DeleteBook(Book book);
        public IEnumerable<Book> GetBooks();
    }
}
