﻿namespace ProductManagementWebApi.DTO
{
    public class ProductOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
