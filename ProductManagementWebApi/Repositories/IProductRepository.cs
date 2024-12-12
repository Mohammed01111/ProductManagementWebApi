using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Repositories
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        bool DeleteProduct(int id);
        Product GetProductById(int id);
        List<Product> GetProducts(int pageNumber, int pageSize);
        int GetTotalProductCount();
        Product UpdateProduct(Product product);
    }
}