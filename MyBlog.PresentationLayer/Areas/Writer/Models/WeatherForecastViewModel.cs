namespace MyBlog.PresentationLayer.Areas.Writer.Models
{
    public class WeatherForecastViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public List<WeatherForecast> Forecasts { get; set; }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public string Weather { get; set; }
        public string WeatherIcon { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public int Humidity { get; set; }
    }

}
