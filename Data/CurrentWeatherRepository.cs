using WeatherApi.Models;
using Microsoft.EntityFrameworkCore;

namespace   WeatherApi.Data
{
    public class CurrentWeatherRepository : ICurrentWeatherRepository
    {
        private readonly AppDbContext _context;

        public  CurrentWeatherRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CurrentWeather> GetCurrentWeatherByDate(DateTime date)
        {
            return  await _context.CurrentWeather.FirstOrDefaultAsync(c => c.CaculationTime == date);
        }

        public async Task InsertCurrentWeatherDetails(CurrentWeather weatherInfo)
        {
            await _context.AddAsync(weatherInfo);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}