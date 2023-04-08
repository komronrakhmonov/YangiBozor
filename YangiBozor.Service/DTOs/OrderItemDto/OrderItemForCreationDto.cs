using YangiBozor.Domain.Entities;

namespace YangiBozor.Service.DTOs.OrderItemDto;
public class OrderItemForCreationDto
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalMoneyForItem { get; set; }
}
