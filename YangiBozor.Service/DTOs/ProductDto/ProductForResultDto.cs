using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Service.DTOs.ProductDto;

public class ProductForResultDto : Auditable
{
    public string ProductPhotoUrl { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryType Category { get; set; }
    public decimal Price { get; set; }
}
