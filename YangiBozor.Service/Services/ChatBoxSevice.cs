using AutoMapper;
using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.ChatBoxDto;
using YangiBozor.Service.DTOs.UserDto;
using YangiBozor.Service.Exeptions;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class ChatBoxSevice : IChatBoxService
{
    private readonly IRepository<ChatBox> repository;
    private readonly IMapper mapper;

    public ChatBoxSevice(IMapper mapper, IRepository<ChatBox> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<ChatBoxForResultDto> AddAsync(ChatBoxForCreationDto dto)
    {
        var massage = await repository.SelectAsync(u => u.UserId == dto.UserId);
        var mapped = mapper.Map<ChatBox>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        var result = await repository.InsertAsync(mapped);
        await repository.SaveAsync();
        return mapper.Map<ChatBoxForResultDto>(result);
    }

    public async Task<bool> DeleteAsync(Expression<Func<ChatBox, bool>> predicate)
    {
        var massage = await repository.SelectAsync(predicate);
        if (massage == null)
            throw new CustomExeption(404, "Not Found!");
        await repository.DeleteAsync(predicate);
        await repository.SaveAsync();
        return true;
    }

    public async Task<ChatBoxForResultDto> GetAsync(Expression<Func<ChatBox, bool>> predicate)
    {
        var massage = await repository.SelectAsync(predicate);
        if (massage == null)
            throw new CustomExeption(404, "Not Found");
        return mapper.Map<ChatBoxForResultDto>(massage);
    }

    public async Task<ChatBoxForResultDto> UpdateAsync(Expression<Func<ChatBox, bool>> predicate, ChatBoxForCreationDto dto)
    {
        var massage = await repository.SelectAsync(predicate);
        if (massage == null)
            throw new CustomExeption(404, "Not Found");
        var mapped = mapper.Map(dto, massage);
        var updated = await repository.UpdateAsync(mapped);
        await repository.SaveAsync();
        return mapper.Map<ChatBoxForResultDto>(updated);
    }
}
