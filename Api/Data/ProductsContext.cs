using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class ProductsContext(DbContextOptions<ProductsContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}