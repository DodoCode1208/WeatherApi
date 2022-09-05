using WeatherApi.Models;

namespace WeatherApi.Data
{
    public interface ICurrentWeatherRepository
    {
        Task SaveChanges();
        Task<CurrentWeather> GetCurrentWeatherByDate(DateTime date);

        Task InsertCurrentWeatherDetails(CurrentWeather weatherInfo);
    }
}