using AutoMapper;
using System.Linq.Expressions;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.ProductDto;
using YangiBozor.Service.Exeptions;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Service.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> productRepository;
    private readonly IMapper mapper;

    public ProductService(IRepository<Product> productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public async Task<ProductForResultDto> AddAsync(ProductForCreationDto dto)
    {
        var product = await productRepository.SelectAsync(u => u.Name == dto.Name);
        if (product != null)
            throw new CustomExeption(400, "Product already exists!");
        var mappedProduct = mapper.Map<Product>(dto);
        mappedProduct.CreatedAt = DateTime.UtcNow;
        var result = await productRepository.InsertAsync(mappedProduct);
        await productRepository.SaveAsync();
        return mapper.Map<ProductForResultDto>(result);
    }


    public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> predicate)
    {
        var product = await productRepository.SelectAsync(predicate);
        if (product == null)
            throw new CustomExeption(404, "Not Found!");
        await productRepository.DeleteAsync(predicate);
        await productRepository.SaveAsync();
        return true;
    }

    public async Task<IEnumerable<ProductForResultDto>> GetAllAsync(Expression<Func<Product, bool>> predicate)
    {
        var products = productRepository.SelectAllAsync();
        products = predicate != null ? products.Where(predicate) : products;
        return mapper.Map<IEnumerable<ProductForResultDto>>(products);
    }

    public async Task<ProductForResultDto> GetAsync(Expression<Func<Product, bool>> predicate)
    {
        var product = await productRepository.SelectAsync(predicate);
        if (product == null)
            throw new CustomExeption(404, "Not Found");
        return mapper.Map<ProductForResultDto>(product);
    }

    public async Task<ProductForResultDto> UpdateAsync(Expression<Func<Product, bool>> predicate, ProductForCreationDto dto)
    {
        var product = await productRepository.SelectAsync(predicate);
        if (product == null)
            throw new CustomExeption(404, "Not Found");
        var mappedProduct = mapper.Map(dto, product);
        var updatedProduct = await productRepository.UpdateAsync(mappedProduct);
        await productRepository.SaveAsync();
        return mapper.Map<ProductForResultDto>(updatedProduct);
    }
}
