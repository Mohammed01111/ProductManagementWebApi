using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetProducts(int pageNumber, int pageSize)
        {
            return _context.Products
                .OrderByDescending(p => p.DateAdded)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Product UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public int GetTotalProductCount()
        {
            return _context.Products.Count();
        }
    }
}
