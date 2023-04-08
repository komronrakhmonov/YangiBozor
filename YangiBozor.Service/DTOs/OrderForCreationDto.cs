namespace YangiBozor.Service.DTOs;

public class OrderForCreationDto
{
    public long UserId { get; set; }
    public User User { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalMoneyToPaid { get; set; }
    public bool IsPaid { get; set; } = false;
}
