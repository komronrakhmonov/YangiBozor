using YangiBozor.Domain.Comons;

namespace YangiBozor.Service.DTOs.ChatBoxDto;

public class ChatBoxForResultDto :Auditable
{
    public long UserId { get; set; }
    public string Content { get; set; }
    public string RepliedContent { get; set; }
}
