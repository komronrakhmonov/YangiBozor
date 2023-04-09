using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.UserDto;
using YangiBozor.Service.Exeptions;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await userRepository.SelectAsync(u => u.Phone == dto.Phone);
        if (user != null)
            throw new CustomExeption(400, "User already exists!");
        var mappedUser = mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;
        var result = await userRepository.InsertAsync(mappedUser);
        await userRepository.SaveAsync();
        return mapper.Map<UserForResultDto>(result);
    }


    public async Task<bool> DeleteAsync(Expression<Func<User, bool>> predicate)
    {
        var user = await userRepository.SelectAsync(predicate);
        if (user == null)
            throw new CustomExeption(404, "Not Found!");
        await userRepository.DeleteAsync(predicate);
        await userRepository.SaveAsync();
        return true;
    }

    public IEnumerable<UserForResultDto> GetAllAsync(Expression<Func<User, bool>> predicate)
    {
        var users = userRepository.SelectAllAsync();
        users = predicate != null ? users.Where(predicate) : users;
        return mapper.Map<IEnumerable<UserForResultDto>>(users);    
    }

    public async Task<UserForResultDto> GetAsync(Expression<Func<User, bool>> predicate)
    {
        var user = await userRepository.SelectAsync(predicate);
        if (user == null)
            throw new CustomExeption(404, "Not Found");
        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateAsync(Expression<Func<User, bool>> predicate, UserForCreationDto dto)
    {
        var user = await userRepository.SelectAsync(predicate);
        if (user == null)
            throw new CustomExeption(404, "Not Found");
        var mappedUser = mapper.Map(dto, user);
        var updatedUser = await userRepository.UpdateAsync(mappedUser);
        await userRepository.SaveAsync();
        return mapper.Map<UserForResultDto>(updatedUser);
    }
}
