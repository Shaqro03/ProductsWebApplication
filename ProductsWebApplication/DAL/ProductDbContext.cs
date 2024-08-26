using Microsoft.EntityFrameworkCore;
using ProductsWebApplication.Models;

namespace ProductsWebApplication.DAL;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductModel> Products { get; set; }
}
