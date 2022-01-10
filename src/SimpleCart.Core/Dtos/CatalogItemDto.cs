namespace SimpleCart.Core.Dtos;

public class CatalogItemDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUri { get; set; }
    public int CategoryId { get; set; }
}