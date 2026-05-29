using Lesson2.Model;
using Microsoft.EntityFrameworkCore;

namespace Lesson2.Data;

public class CatDbContext : DbContext
{
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Breed> Breeds { get; set; }

    public CatDbContext(DbContextOptions<CatDbContext> options) : base(options)
    {
        
    }
}