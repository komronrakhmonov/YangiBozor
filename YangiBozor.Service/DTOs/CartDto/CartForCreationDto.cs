using YangiBozor.Domain.Entities;

namespace YangiBozor.Service.DTOs.CartDto;

public class CartForCreationDto
{
    public long UserId { get; set; }
    public ICollection<Product> Products { get; set; }
}
