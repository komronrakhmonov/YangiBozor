using YangiBozor.Domain.Comons;

namespace YangiBozor.Domain.Entities;

public class OrderItem : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalMoneyForItem { get; set; }
}
