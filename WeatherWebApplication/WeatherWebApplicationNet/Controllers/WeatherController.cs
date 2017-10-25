using APIXULib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherWebApplicationNet.Controllers
{
    public class WeatherController : Controller
    {
        //Replace this with your own key from https://www.apixu.com/ 
        private readonly string key = "412b3379a4c143f59d7115910170610";

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCurrentWeatherByLatLongFromAjax(string latitude, string longitude)
        {
            IRepository repo = new Repository();
            var weatherResult = repo.GetWeatherDataByLatLong(key, latitude, longitude);

            return PartialView("WeatherViewPartial", weatherResult);
        }

        public ActionResult Test()
        {
            IRepository repo = new Repository();
            var GetCityForecastWeatherResult = repo.GetWeatherData(key, GetBy.CityName, "goeteborg", Days.Three);

            return View(GetCityForecastWeatherResult);
        }

    }
}