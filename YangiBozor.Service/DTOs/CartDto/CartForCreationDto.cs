namespace YangiBozor.Service.DTOs.CardDto;

public class CardForCreationDto
{
    public long UserId { get; set; }
    public ICollection<Product> Products { get; set; }
}
