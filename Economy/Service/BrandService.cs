using Economy.Models;
using DTO;

namespace Economy.Service
{
    public class BrandService
    {
       
            private AppDbContext _context;

            public BrandService(AppDbContext context)
            {
                _context = context;
            }

            public IEnumerable<BrandModel> GetAll()
            {
                return _context.Brand;
            }

            public BrandModel GetById(int id)
            {
                return getBrand(id);
            }

            public void Create(Brand model)
            {
                if (_context.Brand.Any(x => x.BrandName == model.BrandName))
                    throw new Exception("Brand with name '" + model.BrandName + "' already exists");
                BrandModel brand = new BrandModel();
                brand.BrandName = model.BrandName;
                _context.Brand.Add(brand);
                _context.SaveChanges();
            }

            public void Update(int id, Brand model)
            {
                var brand = getBrand(id);
                brand.BrandName = model.BrandName;


                _context.Brand.Update(brand);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var brand = getBrand(id);
                _context.Brand.Remove(brand);
                _context.SaveChanges();
            }

            // helper methods

            private BrandModel getBrand(int id)
            {
                var brand = _context.Brand.Find(id);
                if (brand == null) throw new KeyNotFoundException("Brand not found");
                return brand;
            }
    }
}
