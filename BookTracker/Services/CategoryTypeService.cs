using BookTracker.Models;

namespace BookTracker.Services
{
    public class CategoryTypeService : ICategoryTypeService
    {
        public BookTrackerContext _DbContext { get; }
        public CategoryTypeService(BookTrackerContext bookTrackerContext)
        {
            _DbContext = bookTrackerContext;
        }
        public CategoryType AddCategoryType(CategoryType categoryType)
        {
            _DbContext.Add(categoryType);
            _DbContext.SaveChanges();
            return categoryType;
        }

        public void DeleteCategoryType(CategoryType categoryType)
        {
            _DbContext.Remove(categoryType);
            _DbContext.SaveChanges();
        }

        public IEnumerable<CategoryType> GetCategoryTypes()
        {
            return _DbContext.CategoryTypes.ToList();
        }

        public CategoryType UpdateCategoryType(CategoryType categoryType)
        {
            _DbContext.Update(categoryType);
            _DbContext.SaveChanges();
            return categoryType;
        }
    }

    public interface ICategoryTypeService
    {
        public IEnumerable<CategoryType> GetCategoryTypes();
        public CategoryType AddCategoryType(CategoryType categoryType);
        public CategoryType UpdateCategoryType(CategoryType categoryType);
        public void DeleteCategoryType(CategoryType categoryType);
    }
}
