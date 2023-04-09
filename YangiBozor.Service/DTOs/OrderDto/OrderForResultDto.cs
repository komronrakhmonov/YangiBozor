using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Entities;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Service.DTOs.OrderDto;

public class OrderForResultDto : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalMoneyToPaid { get; set; }
    public bool IsPaid { get; set; } = false;
}
