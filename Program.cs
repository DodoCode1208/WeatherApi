using Microsoft.Data.SqlClient;
using WeatherApi.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WeatherApi.Dtos;
using WeatherApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionBuilder = new SqlConnectionStringBuilder();
sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("azuresqlConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionBuilder.ConnectionString));
builder.Services.AddScoped<ICurrentWeatherRepository,CurrentWeatherRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Declaring Endpointsand actions to be performed(light weight api pattern)

// Endpoint to get CurrentWeatherDetails by date.
app.MapGet("/api/v1/WeatherApi/{date}",async(ICurrentWeatherRepository repo , IMapper mapper ,DateTime date) => {

    var currentWeatherInfo = await repo.GetCurrentWeatherByDate(date);
    if(currentWeatherInfo != null)
    {
        return Results.Ok(mapper.Map<CurrentWeatherFetchDto>(currentWeatherInfo));
    }
    else
    {
        return Results.NotFound();
    }
});

// Endpoint to Post/Insert CurrentWeatherDetails by date 
app.MapPost("/api/v1/WeatherApi/",async(ICurrentWeatherRepository repo , IMapper mapper , CurrentWeatherInsertDto currentWeatherRequestDto) =>
{
    var currentWeatherInfoModel = mapper.Map<CurrentWeather>(currentWeatherRequestDto);
    await repo.InsertCurrentWeatherDetails(currentWeatherInfoModel);
    await repo.SaveChanges();

    var currentWeatherFetchDto = mapper.Map<CurrentWeatherFetchDto>(currentWeatherInfoModel);
    return Results.Created($"/api/v1/WeatherApi/{currentWeatherFetchDto.CurrentWeatherId}",currentWeatherFetchDto);
});

app.Run();
