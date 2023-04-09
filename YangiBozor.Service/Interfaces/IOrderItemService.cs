using System.Linq.Expressions;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.ChatBoxDto;
using YangiBozor.Service.DTOs.OrderDto;
using YangiBozor.Service.DTOs.OrderItemDto;
using YangiBozor.Service.DTOs.UserDto;

namespace YangiBozor.Service.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemForResult> AddAsync(OrderItemForCreationDto dto);
    Task<OrderItemForResult> UpdateAsync(Expression<Func<OrderItem, bool>> predicate, OrderItemForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<OrderItem, bool>> predicate);
    Task<OrderItemForResult> GetAsync(Expression<Func<OrderItem, bool>> predicate);
    Task<IEnumerable<OrderItemForResult>> GetAllAsync(Expression<Func<OrderItem, bool>> predicate);
}
