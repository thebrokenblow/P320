using Api.DTOs;
using Api.Exceptions;
using Api.Model;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepositrory productsContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllAsync()
    {
        var products = await productsContext.GetAllAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetByIdAsync(int id)
    {
        var product = await productsContext.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();    
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CreateProduct createProduct)
    {
        if (string.IsNullOrEmpty(createProduct.Name) || createProduct.Name.Length > 100)
        {
            return BadRequest();
        }

        if (string.IsNullOrEmpty(createProduct.Description) || createProduct.Name.Length > 2000)
        {
            return BadRequest();
        }

        if (createProduct.Price <= 0)
        {
            return BadRequest();
        }

        await productsContext.CreateAsync(createProduct);

        return Created();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateProduct updateProduct)
    {
        if (string.IsNullOrEmpty(updateProduct.Name) || updateProduct.Name.Length > 100)
        {
            return BadRequest();
        }

        if (string.IsNullOrEmpty(updateProduct.Description) || updateProduct.Name.Length > 2000)
        {
            return BadRequest();
        }

        if (updateProduct.Price <= 0)
        {
            return BadRequest();
        }

        await productsContext.UpdateAsync(updateProduct);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            await productsContext.DeleteAsync(id);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return Ok();
    }
}
