using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Domain.Entities;

public class Payment : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public PaymentType Type { get; set; }
}
