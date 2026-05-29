using Lesson2.Data;
using Lesson2.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CatDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
builder.Services.AddDbContext<CatDbContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddScoped<ICatRepository, CatRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();