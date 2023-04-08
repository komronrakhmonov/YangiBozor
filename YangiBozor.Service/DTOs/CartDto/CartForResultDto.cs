namespace YangiBozor.Service.DTOs.CardDto;

public class CardDorResultDto : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public ICollection<Product> Products { get; set; }
}
