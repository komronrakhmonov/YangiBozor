using YangiBozor.Domain.Comons;

namespace YangiBozor.Domain.Entities;

public class PaymentType : Auditable
{
    public string Type { get; set; }
}
