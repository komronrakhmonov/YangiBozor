using YangiBozor.Domain.Comons;

namespace YangiBozor.Domain.Entities;

public class Payment : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public int PaymentTypeId { get; set; }
}
