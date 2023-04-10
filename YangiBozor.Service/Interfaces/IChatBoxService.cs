using System.Linq.Expressions;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.ChatBoxDto;
using YangiBozor.Service.DTOs.OrderItemDto;

namespace YangiBozor.Service.Interfaces;

public interface IChatBoxService
{
    Task<ChatBoxForResultDto> AddAsync(ChatBoxForCreationDto dto);
    Task<ChatBoxForResultDto> UpdateAsync(Expression<Func<ChatBox, bool>> predicate, ChatBoxForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<ChatBox, bool>> predicate);
    Task<ChatBoxForResultDto> GetAsync(Expression<Func<ChatBox, bool>> predicate);
}
