using System.Linq.Expressions;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.UserDto;

namespace YangiBozor.Service.Interfaces;

public interface IUserService
{
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> UpdateAsync(Expression<Func<User, bool>> predicate, UserForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate);
    Task<UserForResultDto> GetAsync(Expression<Func<User, bool>> predicate);
    IEnumerable<UserForResultDto> GetAllAsync(Expression<Func<User, bool>> predicate);
}
