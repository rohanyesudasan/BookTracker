using BookTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Controllers
{
    public class BooksController : Controller
    {
        public BookTrackerContext _DbContext { get; set; }
        public BooksController(BookTrackerContext bookTrackerContext)
        {
            _DbContext = bookTrackerContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> books = _DbContext.Books.Include(x => x.Category).ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            var categories = _DbContext.Categories.ToList();
            categories.Insert(0, new Category { NameToken = "Select", Id = 0 });
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Books.Add(book);
                _DbContext.SaveChanges();
                TempData["SuccessMsg"] = "Book added successfully.";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int? bookId)
        {
            var book = _DbContext.Books.Find(bookId);
            var categories = _DbContext.Categories.ToList();
            categories.Insert(0, new Category { NameToken = "Select", Id = 0 });
            ViewBag.Categories = categories;

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Books.Update(book);
                _DbContext.SaveChanges();
                TempData["SuccessMsg"] = "Book updated successfully.";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int? bookId)
        {
            var book = _DbContext.Books.Find(bookId);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? bookId)
        {
            var book = _DbContext.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }
            _DbContext.Books.Remove(book);
            _DbContext.SaveChanges();
            TempData["SuccessMsg"] = "Book deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
