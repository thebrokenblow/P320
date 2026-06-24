using Api.Data;
using Api.DTOs;
using Api.Exceptions;
using Api.Model;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class ProductRepository(ProductsContext productsContext) : IProductRepositrory
{
    public async Task<List<Product>> GetAllAsync()
    {
        return await productsContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await productsContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        return product;
    }

    public async Task CreateAsync(CreateProduct createProduct)
    {
        var product = new Product
        {
            Name = createProduct.Name,
            Description = createProduct.Description,
            Price = createProduct.Price,
        };

        await productsContext.AddAsync(product);
        await productsContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(UpdateProduct updateProduct)
    {
        var updatingProduct = await productsContext.Products.FirstAsync(x => x.Id == updateProduct.Id);

        updatingProduct.Name = updateProduct.Name;
        updatingProduct.Description = updateProduct.Description;
        updatingProduct.Price = updateProduct.Price;

        await productsContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await productsContext.Products.FirstOrDefaultAsync(x => x.Id == id) ?? 
            throw new NotFoundException($"Объект с id: {id} не был найден");

        productsContext.Remove(product);
        await productsContext.SaveChangesAsync();
    }
}
