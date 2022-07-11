using Economy.Models;
using DTO;

namespace Economy.Service
{
    public class ProductService
    {
        private AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _context.Product;
        }

        public ProductModel GetById(int id)
        {
            return getProduct(id);
        }

        public void Create(Product model)
        {
            ProductModel product = new ProductModel();
            product.ProductName = model.ProductName;
            product.BrandId = model.BrandId;
            product.CategoryId = model.CategoryId;
            product.ProductPrice = model.ProductPrice;
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, Product model)
        {
            var product = getProduct(id);
            product.ProductName = model.ProductName;
            product.BrandId = model.BrandId;
            product.CategoryId = model.CategoryId;
            product.ProductPrice = model.ProductPrice;
            _context.Product.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = getProduct(id);
            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        // helper methods

        private ProductModel getProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null) throw new KeyNotFoundException("Category not found");
            return product;
        }
    }
}
