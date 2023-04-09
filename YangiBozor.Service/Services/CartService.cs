using AutoMapper;
using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.CartDto;
using YangiBozor.Service.DTOs.ProductDto;
using YangiBozor.Service.Exeptions;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class CartService : ICartService
{
    private readonly IRepository<Cart> cartRepository;
    private readonly IMapper mapper;

    public CartService(IRepository<Cart> cartRepository, IMapper mapper)
    {
        this.cartRepository = cartRepository;
        this.mapper = mapper;
    }

    public async Task<CartForResultDto> AddAsync(CartForCreationDto dto)
    {
        var cart = await cartRepository.SelectAsync(u => u.UserId == dto.UserId);
        if (cart != null)
            throw new CustomExeption(400, "Cart already exists!");
        var mappedCart = mapper.Map<Cart>(dto);
        mappedCart.CreatedAt = DateTime.UtcNow;
        var result = await cartRepository.InsertAsync(mappedCart);
        await cartRepository.SaveAsync();
        return mapper.Map<CartForResultDto>(result);
    }


    public async Task<bool> DeleteAsync(Expression<Func<Cart, bool>> predicate)
    {
        var cart = await cartRepository.SelectAsync(predicate);
        if (cart == null)
            throw new CustomExeption(404, "Not Found!");
        await cartRepository.DeleteAsync(predicate);
        await cartRepository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<CartForResultDto>> GetAllAsync(Expression<Func<Cart, bool>> predicate)
    {
        var carts = cartRepository.SelectAllAsync();
        carts = predicate != null ? carts.Where(predicate) : carts;
        return mapper.Map<IEnumerable<CartForResultDto>>(carts);
    }

    public async Task<CartForResultDto> GetAsync(Expression<Func<Cart, bool>> predicate)
    {
        var cart = await cartRepository.SelectAsync(predicate);
        if (cart == null)
            throw new CustomExeption(404, "Not Found");
        return mapper.Map<CartForResultDto>(cart);
    }

    public async Task<CartForResultDto> UpdateAsync(Expression<Func<Cart, bool>> predicate, CartForCreationDto dto)
    {
        var cart = await cartRepository.SelectAsync(predicate);
        if (cart == null)
            throw new CustomExeption(404, "Not Found");
        var mappedCart = mapper.Map(dto, cart);
        var updatedCart = await cartRepository.UpdateAsync(mappedCart);
        await cartRepository.SaveAsync();
        return mapper.Map<CartForResultDto>(updatedCart);
    }
}
