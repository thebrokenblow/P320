using Lesson2.Model;
using Microsoft.EntityFrameworkCore;

namespace Lesson2.Data;

public class CatDbContext(DbContextOptions<CatDbContext> options) : DbContext(options)
{
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Breed> Breeds { get; set; }
}