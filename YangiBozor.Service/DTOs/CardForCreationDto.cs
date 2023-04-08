namespace YangiBozor.Service.DTOs;

public class CardForCreationDto
{
    public long UserId { get; set; }
    public ICollection<Product> Products { get; set; }
}
