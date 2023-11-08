using AutoMapper;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Services.DTOs.Users;
using BeautyMakers.Services.DTOs.Salons;

namespace BeautyMakers.Services.Mappers;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();

        CreateMap<Salon,SalonForCreationDto>().ReverseMap();
        CreateMap<Salon, SalonForUpdateDto>().ReverseMap();
        CreateMap<Salon, SalonForResultDto>().ReverseMap();
    }
}
