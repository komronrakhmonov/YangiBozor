using AutoMapper;
using YangiBozor.Domain.Entities;

namespace YangiBozor.Service.Mappers;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<User>
	}
}
