using ProductManagementWebApi.DTO;

namespace ProductManagementWebApi.Services
{
    public interface IProductService
    {
        ProductOutputDto AddProduct(ProductInputDto productDto);
        bool DeleteProduct(int id);
        ProductOutputDto GetProductById(int id);
        List<ProductOutputDto> GetProducts(int pageNumber, int pageSize);
        ProductOutputDto UpdateProduct(int id, ProductInputDto productDto);
    }
}