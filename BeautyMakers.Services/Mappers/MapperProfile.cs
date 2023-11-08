using AutoMapper;
using BeautyMakers.Domain.Entities;
using BeautyMakers.Services.DTOs.Users;
using BeautyMakers.Services.DTOs.Salons;
using BeautyMakers.Services.DTOs.PastWorks;
using BeautyMakers.Services.DTOs.Appoinments;
using BeautyMakers.Services.DTOs.AppoinmentResults;
using BeautyMakers.Services.DTOs.BeautyProfessionals;

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

        CreateMap<Appointment,AppointmentForCreationDto>().ReverseMap();
        CreateMap<Appointment, AppointmentForResultDto>().ReverseMap();
        CreateMap<Appointment, AppointmentForUpdateDto>().ReverseMap();

        CreateMap<BeautyProfessional,BeautyProfessionalForCreationDto>().ReverseMap();
        CreateMap<BeautyProfessional, BeautyProfessionalForUpdateDto>().ReverseMap();
        CreateMap<BeautyProfessional, BeautyProfessionalForResultDto>().ReverseMap();

        CreateMap<AppointmentResult,AppointmentResultDto>().ReverseMap();
        CreateMap<AppointmentResult, AppointmentResultForUpdateDto>().ReverseMap();
        CreateMap<AppointmentResult, AppointmentResultForCreationDto>().ReverseMap();

        CreateMap<PastWork,PastWorkForCreationDto>().ReverseMap();
        CreateMap<PastWork, PastWorkForResultDto>().ReverseMap();
        CreateMap<PastWork, PastWorkForUpdateDto>().ReverseMap();
    }
}
