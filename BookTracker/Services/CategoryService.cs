using BookTracker.Models;

namespace BookTracker.Services
{
    public class CategoryService : ICategoryService
    {
        public BookTrackerContext _DbContext { get; set; }
        public CategoryService(BookTrackerContext bookTrackerContext)
        {
            _DbContext = bookTrackerContext;
        }

        public Category AddCategory(Category category)
        {
            _DbContext.Add(category);
            _DbContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(Category category)
        {
            _DbContext.Remove(category);
            _DbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _DbContext.Categories.ToList();
        }

        public Category UpdateCategory(Category category)
        {
            _DbContext.Update(category);
            _DbContext.SaveChanges();
            return category;
        }
    }
    public interface ICategoryService
    {
        public Category AddCategory(Category category);
        public IEnumerable<Category> GetCategories();
        public Category UpdateCategory(Category category);
        public void DeleteCategory(Category category);
    }

}
