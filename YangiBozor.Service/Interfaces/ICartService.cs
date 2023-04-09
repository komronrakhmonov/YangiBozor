using System.Linq.Expressions;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.CartDto;

namespace YangiBozor.Service.Interfaces;

public interface ICartService
{

    Task<CartForResultDto> AddAsync(CartForCreationDto dto);
    Task<CartForResultDto> UpdateAsync(Expression<Func<Cart, bool>> predicate, CartForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<Cart, bool>> predicate);
    Task<CartForResultDto> GetAsync(Expression<Func<Cart, bool>> predicate);
    Task<IEnumerable<CartForResultDto>> GetAllAsync(Expression<Func<Cart, bool>> predicate);
}