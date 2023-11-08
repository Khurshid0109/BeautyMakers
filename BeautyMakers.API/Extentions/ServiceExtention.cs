using System.Text;
using System.Reflection;
using Microsoft.OpenApi.Models;
using BeautyMakers.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using BeautyMakers.Data.IRepositories;
using BeautyMakers.Services.Services.Users;
using BeautyMakers.Services.Services.Salons;
using BeautyMakers.Services.Interfaces.Users;
using BeautyMakers.Services.Interfaces.Salons;
using BeautyMakers.Services.Services.PastWorks;
using BeautyMakers.Services.Services.Appoinments;
using BeautyMakers.Services.Interfaces.PastWorks;
using BeautyMakers.Services.Interfaces.Appoinments;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BeautyMakers.Services.Services.AppoinmentResults;
using BeautyMakers.Services.Interfaces.AppoinmentResults;
using BeautyMakers.Services.Services.BeautyProfessionals;
using BeautyMakers.Services.Interfaces.BeautyProfessionals;

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

        services.AddScoped<IAuthService, AuthService>();

    }
    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shamsheer.Api", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{ }
            }
        });
        });
    }
}
