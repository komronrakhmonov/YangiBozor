using AutoMapper;
using Azure.Core;
using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.OrderDto;
using YangiBozor.Service.DTOs.OrderItemDto;
using YangiBozor.Service.DTOs.UserDto;
using YangiBozor.Service.Exeptions;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IRepository<OrderItem> repository;
    private readonly IMapper mapper;

    public OrderItemService(IRepository<OrderItem> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }


    public async Task<OrderItemForResult> AddAsync(OrderItemForCreationDto dto)
    {
        var item = await repository.SelectAsync(u => u.OrderId == dto.OrderId);
        if (item is not null)
            throw new CustomExeption(400, "User already exists!");
        var mappedOrderItem = mapper.Map<OrderItem>(dto);
        mappedOrderItem.CreatedAt = DateTime.UtcNow;
        var result = await repository.InsertAsync(mappedOrderItem);
        await repository.SaveAsync();
        return mapper.Map<OrderItemForResult>(result);
    }

    public async Task<bool> DeleteAsync(Expression<Func<OrderItem, bool>> predicate)
    {
        var item = await repository.SelectAsync(predicate);
        if (item is null)
            throw new CustomExeption(404, "Not Found!");
        await repository.DeleteAsync(predicate);
        await repository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<OrderItemForResult>> GetAllAsync(Expression<Func<OrderItem, bool>> predicate)
    {
        var items = repository.SelectAllAsync();
        items = predicate != null ? items.Where(predicate) : items;
        return mapper.Map<IEnumerable<OrderItemForResult>>(items);
    }

    public async Task<OrderItemForResult> GetAsync(Expression<Func<OrderItem, bool>> predicate)
    {
        var item = repository.SelectAsync(predicate);
        if (item is null) throw new CustomExeption(404, "Not Found!");
        //var result = mapper.Map<OrderItemForResult>(item);
        // return result;
        return mapper.Map<OrderItemForResult>(item);
    }

    public async Task<OrderItemForResult> UpdateAsync(Expression<Func<OrderItem, bool>> predicate, OrderItemForCreationDto dto)
    {
        var item = await repository.SelectAsync(predicate);
        if (item == null)
            throw new CustomExeption(404, "Not Found");
        var mappedItem = mapper.Map(dto, item);
        var updatedItem = await repository.UpdateAsync(mappedItem);
        await repository.SaveAsync();
        return mapper.Map<OrderItemForResult>(updatedItem);
    }
}
