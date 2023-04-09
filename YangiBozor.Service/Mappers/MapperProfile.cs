using AutoMapper;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.ProductDto;
using YangiBozor.Service.DTOs.UserDto;

namespace YangiBozor.Service.Mappers;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<User, UserForCreationDto>().ReverseMap();
		CreateMap<User, UserForResultDto>().ReverseMap();
		CreateMap<Product, ProductForResultDto>().ReverseMap();
	}
}
