using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Linq;
using MyBlog.PresentationLayer.Areas.Writer.Models;
using System.Collections.Generic;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterLayoutDashboardWeatherChartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string api = "005c3d4023416e627507d8edf707781e";
            string connection = "https://api.openweathermap.org/data/2.5/forecast?q=Bursa&mode=xml&units=metric&appid=" + api + "&lang=tr";
            XDocument document = XDocument.Load(connection);

            var cityElement = document.Descendants("location").ElementAtOrDefault(0);
            var countryElement = document.Descendants("country").ElementAtOrDefault(0);

            var forecasts = document.Descendants("time")
                .Select(forecast => new WeatherForecast
                {
                    Date = DateTime.Parse(forecast.Attribute("from").Value),
                    Weather = forecast.Descendants("symbol").ElementAtOrDefault(0)?.Attribute("name")?.Value ?? "N/A",
                    WeatherIcon = forecast.Descendants("symbol").ElementAtOrDefault(0)?.Attribute("var")?.Value ?? "01d",
                    Temperature = float.TryParse(forecast.Descendants("temperature").ElementAtOrDefault(0)?.Attribute("value")?.Value, out var temp) ? temp : 0,
                    WindSpeed = float.TryParse(forecast.Descendants("windSpeed").ElementAtOrDefault(0)?.Attribute("mps")?.Value, out var wind) ? wind : 0,
                    Humidity = int.TryParse(forecast.Descendants("humidity").ElementAtOrDefault(0)?.Attribute("value")?.Value, out var humidity) ? humidity : 0
                }).ToList();

            var weatherForecastViewModel = new WeatherForecastViewModel
            {
                City = cityElement?.Element("name")?.Value ?? "Bursa",
                Country = countryElement?.Value ?? "Turkey",
                Forecasts = forecasts
            };

            return View(weatherForecastViewModel);
        }
    }
}
