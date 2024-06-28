using Microsoft.AspNetCore.Mvc;
using MyBlog.PresentationLayer.Models;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Xml.Linq;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutDashboardWeatherChartComponentPartial : ViewComponent
    {
        private readonly string apiKey = "005c3d4023416e627507d8edf707781e";
        private readonly string apiUrl = "https://api.openweathermap.org/data/2.5/forecast?q=Bursa,tr&units=metric&lang=tr&appid={0}";
        private static readonly Dictionary<string, string> weatherDescriptions = new Dictionary<string, string>
        {
            { "clear sky", "Açık Hava" },
            { "few clouds", "Az Bulutlu" },
            { "scattered clouds", "Parçalı Bulutlu" },
            { "broken clouds", "Çok Bulutlu" },
            { "shower rain", "Sağanak Yağmurlu" },
            { "rain", "Yağmurlu" },
            { "thunderstorm", "Gök Gürültülü Fırtına" },
            { "snow", "Karlı" },
            { "mist", "Sisli" },
            { "light rain", "Hafif Yağmurlu" },
        };

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weatherForecast = await GetWeatherForecastAsync();
            return View(weatherForecast);
        }

        private async Task<WeatherForecastViewModel> GetWeatherForecastAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(string.Format(apiUrl, apiKey));
                var json = JObject.Parse(response);

                var weatherDescription = json["list"][0]["weather"][0]["description"].ToString();
                var translatedDescription = weatherDescriptions.ContainsKey(weatherDescription) ? weatherDescriptions[weatherDescription] : weatherDescription;
                var formattedDescription = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(translatedDescription.ToLower());

                var weatherForecast = new WeatherForecastViewModel
                {
                    City = json["city"]["name"].ToString(),
                    Country = json["city"]["country"].ToString(),
                    CurrentTemperature = (double)json["list"][0]["main"]["temp"],
                    CurrentWeatherDescription = formattedDescription,
                    CurrentHumidity = (int)json["list"][0]["main"]["humidity"],
                    CurrentWindSpeed = (double)json["list"][0]["wind"]["speed"],
                    DailyForecasts = new List<DailyForecast>()
                };

                for (int i = 0; i < json["list"].Count(); i += 8)
                {
                    var dailyForecast = new DailyForecast
                    {
                        Date = json["list"][i]["dt_txt"].ToString(),
                        Temperature = (double)json["list"][i]["main"]["temp"],
                        WeatherIcon = json["list"][i]["weather"][0]["icon"].ToString()
                    };
                    weatherForecast.DailyForecasts.Add(dailyForecast);
                }

                return weatherForecast;
            }
        }
    }
}
