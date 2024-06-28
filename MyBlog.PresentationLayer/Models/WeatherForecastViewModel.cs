using System;
using System.Collections.Generic;

namespace MyBlog.PresentationLayer.Models
{
    public class WeatherForecastViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public double CurrentTemperature { get; set; }
        public string CurrentWeatherDescription { get; set; }
        public int CurrentHumidity { get; set; }
        public double CurrentWindSpeed { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class DailyForecast
    {
        public string Date { get; set; }
        public double Temperature { get; set; }
        public string WeatherIcon { get; set; }
    }
}
