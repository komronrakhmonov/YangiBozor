using System.Linq.Expressions;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.OrderDto;
using YangiBozor.Service.DTOs.UserDto;

namespace YangiBozor.Service.Interfaces;

public interface IOrderService
{
    Task<OrderForResultDto> AddAsync(OrderForCreationDto dto);
    Task<OrderForResultDto> UpdateAsync(Expression<Func<Order, bool>> predicate, OrderForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<Order, bool>> predicate);
    Task<OrderForResultDto> GetAsync(Expression<Func<Order, bool>> predicate);
    Task<IEnumerable<OrderForResultDto>> GetAllAsync(Expression<Func<Order, bool>> predicate);
}
