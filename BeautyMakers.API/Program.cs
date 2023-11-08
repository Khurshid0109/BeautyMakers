using BeautyMakers.Data.Data;
using BeautyMakers.API.Extentions;
using BeautyMakers.Services.Helpers;
using BeautyMakers.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using BeautyMakers.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
//I registered injections in this file
builder.Services.CustomExtention();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AAA", builder => builder.AllowCredentials());
});

//The path for wwwroot folder
WebHostEnvironment.WebRootPath = Path.GetFullPath("wwwroot");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
