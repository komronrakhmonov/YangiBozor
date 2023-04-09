using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Entities;

namespace YangiBozor.Service.DTOs.CartDto;

public class CartForResultDto : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public ICollection<Product> Products { get; set; }
}
