using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private List<CityWeather> cityWeatherList = new List<CityWeather>()
			{
				new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33},

				new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60},

				new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82},

				new CityWeather() { CityUniqueCode = "GDA", CityName = "Gdańsk", DateAndTime = DateTime.Now, TemperatureFahrenheit = 30},
				
				new CityWeather() { CityUniqueCode = "WRO", CityName = "Wrocław", DateAndTime = DateTime.Now, TemperatureFahrenheit = 90},
				
				new CityWeather() { CityUniqueCode = "KRK", CityName = "Kraków", DateAndTime = DateTime.Now, TemperatureFahrenheit = 50}
			};

		[Route("/")]
		[Route("home")]
		public IActionResult Index()
		{
			//ViewData["cityWeatherList"] = cityWeatherList;
			//ViewBag.CityWeatherList = cityWeatherList;

			return View(cityWeatherList);
		}

		[Route("weather/{cityCode}")]
		public IActionResult Details()
		{
			var cityCode = HttpContext.Request.RouteValues["cityCode"];

			foreach (CityWeather item in cityWeatherList)
			{
				if (item.CityUniqueCode == cityCode.ToString())
				{
					return View(item);
				}
			}

			HttpContext.Response.StatusCode = 404;
			return View("ErrorPage"); // should it return 404??
									  //return NotFound("WRONG CITY CODE!!!!");
		}
	}
}
