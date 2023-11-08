using BeautyMakers.Data.Repositories;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Services.Users;
using BeautyMakers.Services.Services.Salons;
using BeautyMakers.Services.Interfaces.Users;
using BeautyMakers.Services.Interfaces.Salons;
using BeautyMakers.Services.Services.Appoinments;
using BeautyMakers.Services.Interfaces.Appoinments;
using BeautyMakers.Services.Services.BeautyProfessionals;
using BeautyMakers.Services.Interfaces.BeautyProfessionals;
using BeautyMakers.Services.Interfaces.AppoinmentResults;
using BeautyMakers.Services.Services.AppoinmentResults;
using BeautyMakers.Services.Interfaces.PastWorks;
using BeautyMakers.Services.Services.PastWorks;

namespace BeautyMakers.API.Extentions;
public static class ServiceExtention 
{
    public static void CustomExtention(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<ISalonRepository, SalonRepository>();
        services.AddScoped<ISalonService, SalonService>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IPastWorksRepository, PastWorksRepository>();
        services.AddScoped<IPastWorkService, PastWorkService>();

        services.AddScoped<IBeautyProfessionalRepository, BeautyProfessionalRepository>();
        services.AddScoped<IBeautyProfessionalService,BeautyProfessionalService>();

        services.AddScoped<IAppointmentResultRepository, AppointmentResultRepository>();
        services.AddScoped<IAppointmentResultService, AppointmentResultService>();

        services.AddScoped<IAppointmentRepository,AppointmentRepository>();
        services.AddScoped<IAppointmentService, AppointmentService>();

    }
}
