using YangiBozor.Domain.Comons;
using YangiBozor.Domain.Enums;

namespace YangiBozor.Domain.Entities;

public class ChatBox : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public string RepliedContent { get; set; }
}
