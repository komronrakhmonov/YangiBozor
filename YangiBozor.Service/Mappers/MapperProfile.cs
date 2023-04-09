using AutoMapper;
using YangiBozor.Domain.Entities;
using YangiBozor.Service.DTOs.ChatBoxDto;
using YangiBozor.Service.DTOs.OrderDto;
using YangiBozor.Service.DTOs.OrderItemDto;
using YangiBozor.Service.DTOs.UserDto;

namespace YangiBozor.Service.Mappers;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<User, UserForCreationDto>().ReverseMap();
		CreateMap<User, UserForResultDto>().ReverseMap();

		CreateMap<OrderItem, OrderItemForCreationDto>().ReverseMap();
		CreateMap<OrderItemForResult,OrderItem>().ReverseMap();

		CreateMap<OrderForCreationDto, Order>().ReverseMap();
		CreateMap<OrderForResultDto, Order>().ReverseMap();

		CreateMap<ChatBoxForCreationDto, ChatBox>().ReverseMap();
		CreateMap<ChatBoxForResultDto, ChatBox>().ReverseMap();
	}
}
