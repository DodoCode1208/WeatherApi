using AutoMapper;
using WeatherApi.Dtos;
using WeatherApi.Models;

namespace WeatherApi.Mapper
{
    public class WeatherInfoMapper : Profile
    {
        public WeatherInfoMapper()
        {
            //Mapping -- Source = CurrentWeather(Model) , Target = CurrentWeatherFetchDto (Data Transfer Object)
            CreateMap<CurrentWeather,CurrentWeatherFetchDto>();
            //Mapping -- Source =  CurrentWeatherInsertDto (Data Transfer Object) , Target = CurrentWeather (Sata Transfer Object)
            CreateMap<CurrentWeatherInsertDto,CurrentWeather>();
            
        }

    }
}