using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIXULib;

namespace WeatherWebApplication.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            string key = "412b3379a4c143f59d7115910170610";
            IRepository repo = new Repository();
            var GetCityForecastWeatherResult = repo.GetWeatherData(key, GetBy.CityName, "goeteborg", Days.Three);

            return View(GetCityForecastWeatherResult);
        }
    }
}