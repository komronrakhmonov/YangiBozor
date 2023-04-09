using YangiBozor.Domain.Comons;

namespace YangiBozor.Service.DTOs.ProductDto;

public class ProductForResultDto : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
}
