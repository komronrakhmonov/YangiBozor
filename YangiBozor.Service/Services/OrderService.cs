using AutoMapper;
using System;
using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.OrderDto;
using YangiBozor.Service.DTOs.UserDto;
using YangiBozor.Service.Exeptions;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> orderRepository;
    private readonly IMapper mapper;

    public OrderService(IRepository<Order> orderRepository, IMapper mapper)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
    }

    public async Task<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
        var order = await orderRepository.SelectAsync(u => u.UserId == dto.UserId);
        if (order != null)
            throw new CustomExeption(400, "User already exists!");
        var mappedOrder = mapper.Map<Order>(dto);
        mappedOrder.CreatedAt = DateTime.UtcNow;
        var result = await orderRepository.InsertAsync(mappedOrder);
        await orderRepository.SaveAsync();
        return mapper.Map<OrderForResultDto>(result);
    }

    public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> predicate)
    {
        var order = await orderRepository.SelectAsync(predicate);
        if (order == null)
            throw new CustomExeption(404, "Not Found!");
        await orderRepository.DeleteAsync(predicate);
        await orderRepository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<OrderForResultDto>> GetAllAsync(Expression<Func<Order, bool>> predicate)
    {
        var orders = orderRepository.SelectAllAsync();
        orders = predicate != null ? orders.Where(predicate) : orders;
        return mapper.Map<IEnumerable<OrderForResultDto>>(orders);
    }

    public async Task<OrderForResultDto> GetAsync(Expression<Func<Order, bool>> predicate)
    {
        var order = await orderRepository.SelectAsync(predicate);
        if (order == null)
            throw new CustomExeption(404, "Not Found");
        return mapper.Map<OrderForResultDto>(order);
    }

    public async Task<OrderForResultDto> UpdateAsync(Expression<Func<Order, bool>> predicate, OrderForCreationDto dto)
    {
        var order = await orderRepository.SelectAsync(predicate);
        if (order == null)
            throw new CustomExeption(404, "Not Found");
        var mappedOrder = mapper.Map(dto, order);
        var updatedOrder = await orderRepository.UpdateAsync(mappedOrder);
        await orderRepository.SaveAsync();
        return mapper.Map<OrderForResultDto>(updatedOrder);

    }
}




    