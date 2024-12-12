using AutoMapper;
using ProductManagementWebApi.DTO;
using ProductManagementWebApi.Models;
using ProductManagementWebApi.Repositories;

namespace ProductManagementWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProductOutputDto AddProduct(ProductInputDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.DateAdded = DateTime.UtcNow;

            var addedProduct = _repository.AddProduct(product);
            return _mapper.Map<ProductOutputDto>(addedProduct);
        }

        public ProductOutputDto GetProductById(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null) return null;

            return _mapper.Map<ProductOutputDto>(product);
        }

        public List<ProductOutputDto> GetProducts(int pageNumber, int pageSize)
        {
            var products = _repository.GetProducts(pageNumber, pageSize);
            return _mapper.Map<List<ProductOutputDto>>(products);
        }

        public ProductOutputDto UpdateProduct(int id, ProductInputDto productDto)
        {
            var existingProduct = _repository.GetProductById(id);
            if (existingProduct == null) return null;

            _mapper.Map(productDto, existingProduct);
            var updatedProduct = _repository.UpdateProduct(existingProduct);
            return _mapper.Map<ProductOutputDto>(updatedProduct);
        }

        public bool DeleteProduct(int id)
        {
            return _repository.DeleteProduct(id);
        }
    }
}

