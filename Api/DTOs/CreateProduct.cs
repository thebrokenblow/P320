namespace Api.DTOs;

public class CreateProduct
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
}