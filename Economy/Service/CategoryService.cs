using DTO;
using Economy.Models;

namespace Economy.Service
{
    public class CategoryService
    {
        private AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            return _context.Category;
        }

        public CategoryModel GetById(int id)
        {
            return getCategory(id);
        }

        public void Create(Category model)
        {
            if (_context.Category.Any(x => x.CategoryName == model.CategoryName))
                throw new Exception("Category with name '" + model.CategoryName + "' already exists");
            CategoryModel category = new CategoryModel();
            category.CategoryName = model.CategoryName;
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category model)
        {
            var category = getCategory(id);
            category.CategoryName = model.CategoryName;


            _context.Category.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = getCategory(id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }

        // helper methods

        private CategoryModel getCategory(int id)
        {
            var category = _context.Category.Find(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }
    }
}
