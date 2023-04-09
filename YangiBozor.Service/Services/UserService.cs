using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.UserDto;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository
    public Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> GetAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> UpdateAsync(Expression<Func<User, bool>> predicate, UserForCreationDto dto)
    {
        throw new NotImplementedException();
    }
}
