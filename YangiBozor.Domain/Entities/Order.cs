using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Domain.Entities;

public class Order : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalMoneyToPaid { get; set; }
    public bool IsPaid { get; set; } = false;
}
