using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApi.Dtos
{   
    public class CurrentWeatherInsertDto
    {   
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
}