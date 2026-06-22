using Api.Data;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductsContext productsContext) : ControllerBase
{
    [HttpGet]
    public async Task<List<Product>> GetAsync()
    {
        return await productsContext.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Product> GetByIdAsync(int id)
    {
        return await productsContext.Products.FirstAsync(x => x.Id == id);
    }

    [HttpPost]
    public async Task CreateAsync([FromBody] Product product)
    {
        await productsContext.AddAsync(product);
        await productsContext.SaveChangesAsync();
    }

    [HttpPut]
    public async Task UpdateAsync([FromBody] Product product)
    {
        var updatingProduct = await productsContext.Products.FirstAsync(x => x.Id == product.Id);

        updatingProduct.Name = product.Name;
        updatingProduct.Description = product.Description;
        updatingProduct.Price = product.Price;

        await productsContext.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task UpdateAsync(int id)
    {
        var product = await productsContext.Products.FirstAsync(x => x.Id == id);

        productsContext.Remove(product);
        await productsContext.SaveChangesAsync();
    }
}
