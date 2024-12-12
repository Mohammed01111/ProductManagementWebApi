
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagementWebApi.DTO;
using ProductManagementWebApi.Models;
using ProductManagementWebApi.Repositories;
using ProductManagementWebApi.Services;
using System.Reflection;

namespace ProductManagementWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure AutoMapper to scan the assembly for profiles
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Ensure this scans for MappingProfile

            // Dependency Injection
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }

    // AutoMapper Profile
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductOutputDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<ProductInputDto, Product>();
        }
    }
}
