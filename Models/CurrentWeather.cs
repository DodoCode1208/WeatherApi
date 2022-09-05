using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApi.Models
{   
    public class CurrentWeather
    {   
        [Key]
        public int  CurrentWeatherId { get; set; }
        public int? Visibility { get; set; }
        public DateTime? CaculationTime { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public WeatherMainInfo MainInfo { get; set; }
        public WindParameters  WindParamInfo { get; set; }
        public ICollection<Weather> WeatherInfo { get; set; }
        public RainVolumeInfo Rain { get; set; }
        public SnowVolumeInfo Snow { get; set; }
        public CloudinessInfo CloudinessPercentageValue { get; set; }   

    }

    public class Weather
    {
        public int WeatherId { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }

        public string WeatherIconId { get; set; }
        public CurrentWeather CurrentWeather { get; set; }

    }

    public class WindParameters
    {
        [Key]
        public int WindParamId { get; set; }
        public decimal? WindSpeed { get; set; }
        public decimal? WindDirection { get; set; }
        public decimal? WindGust { get; set; }
        
        [ForeignKey("CurrentWeather")]
        public int CurrentWeatherId { get; set; }
    }

    public class WeatherMainInfo
    {
        [Key]
        public int WeatherMainInfoId { get; set; }
        public decimal? TemperatureInfo { get; set; }
        public decimal? TemperatureFeelsLikeValue { get; set; }
        public decimal? TemperatureMinValue { get; set; }
        public decimal? TemperatureMaxValue { get; set; }    
        public decimal? AtmosphericPressureSeaLevel { get; set; }
        public decimal? AtmosphericPressureGroundLevel { get; set; }
        public decimal? Humidity { get; set; }

        [ForeignKey("CurrentWeather")]
        public int CurrentWeatherId { get; set; }

    }   
    public class RainVolumeInfo
    {
        [Key]
        public int RainVolumeInfoId { get; set; }
        public decimal? RainInAnHour { get; set; }
        public decimal? RainIn3HourPeriod { get; set; }

        [ForeignKey("CurrentWeather")]
        public int CurrentWeatherId { get; set; }
    }

     public class SnowVolumeInfo
    {
        [Key]
        public int SnowVolumeInfoId { get; set; }
        public decimal? SnowInAnHour { get; set; }
        public decimal? SnowIn3HourPeriod { get; set; }

        [ForeignKey("CurrentWeather")]
        public int CurrentWeatherId { get; set; }
    }
    public class CloudinessInfo
    {
       [Key]
       public int CloudinessInfoId { get; set; }
       public decimal? CloudinessPercentageValue { get; set; }

       [ForeignKey("CurrentWeather")]
       public int CurrentWeatherId { get; set; }    
    }
}