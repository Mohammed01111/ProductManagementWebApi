using System.ComponentModel.DataAnnotations;

namespace ProductManagementWebApi.DTO
{
    public class ProductInputDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Category { get; set; } = "general";
    }
}
