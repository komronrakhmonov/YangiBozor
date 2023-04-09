using YangiBozor.Domain.Entities;

namespace YangiBozor.Service.DTOs.ChatBoxDto;

public class ChatBoxForCreationDto
{
    public long UserId { get; set; }
    public string Content { get; set; }
    public string RepliedContent { get; set; }
}
