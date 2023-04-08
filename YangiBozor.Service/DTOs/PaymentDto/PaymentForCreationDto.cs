using YangiBozor.Domain.Entities;

namespace YangiBozor.Service.DTOs.PaymentDto;
public class PaymentForCreationDto
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public int PaymentTypeId { get; set; }
}
