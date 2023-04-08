namespace YangiBozor.Service.DTOs.ProductDto;

public class ProductForCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
}
