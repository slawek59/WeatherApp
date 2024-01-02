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

				new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82}
			};

		[Route("/")]
		[Route("home")]
		public IActionResult Index()
		{
			

			//ViewData["cityWeatherList"] = cityWeatherList;
			//ViewBag.CityWeatherList = cityWeatherList;

			return View(cityWeatherList);
		}

		[Route("weather/test")]
		public IActionResult Details()
		{
			
			return View(cityWeatherList[0]);
		}
	}
}
