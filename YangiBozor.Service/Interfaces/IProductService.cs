using System.Linq.Expressions;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.ProductDto;
using YangiBozor.Service.DTOs.UserDto;

namespace YangiBozor.Service.Interfaces;

public interface IProductService
{

    Task<ProductForResultDto> AddAsync(ProductForCreationDto dto);
    Task<ProductForResultDto> UpdateAsync(Expression<Func<Product, bool>> predicate, ProductForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<Product, bool>> predicate);
    Task<ProductForResultDto> GetAsync(Expression<Func<Product, bool>> predicate);
    IEnumerable<ProductForResultDto> GetAllAsync(Expression<Func<Product, bool>> predicate);
}

