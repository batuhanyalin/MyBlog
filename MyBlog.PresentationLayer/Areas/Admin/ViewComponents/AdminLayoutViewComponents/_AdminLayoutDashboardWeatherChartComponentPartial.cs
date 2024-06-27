using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutDashboardWeatherChartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string api = "005c3d4023416e627507d8edf707781e";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Bursa&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v1 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
