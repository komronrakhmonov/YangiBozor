using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Domain.Entities;

public class Product : Auditable
{
    public string ProductPhotoUrl { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryType Type { get; set; }
    public decimal Price { get; set; }
}
