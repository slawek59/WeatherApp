using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private List<CityWeather> cityWeatherList = new List<CityWeather>()
			{
				new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Now.AddHours(-1), TemperatureFahrenheit = 33},

				new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Now.AddHours(-6), TemperatureFahrenheit = 60},

				// this date and time is just for the sake of being here
				new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82},

				new CityWeather() { CityUniqueCode = "GDA", CityName = "Gdańsk", DateAndTime = DateTime.Now, TemperatureFahrenheit = 30},
				
				new CityWeather() { CityUniqueCode = "WRO", CityName = "Wrocław", DateAndTime = DateTime.Now, TemperatureFahrenheit = 90},
				
				new CityWeather() { CityUniqueCode = "KRK", CityName = "Kraków", DateAndTime = DateTime.Now, TemperatureFahrenheit = 50}
			};

		[Route("/")]
		[Route("home")]
		public IActionResult Index()
		{
			return View(cityWeatherList);
		}

		[Route("weather/{cityCode?}")]
		public IActionResult Details(string cityCode)
		{
			if (string.IsNullOrEmpty(cityCode))
			{
				HttpContext.Response.StatusCode = 404;
				return View("ErrorPage");
			}

			CityWeather? city = cityWeatherList.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();

			if (city == null)
			{
				HttpContext.Response.StatusCode = 404;
				return View("ErrorPage");
			}

			return View(city);
		}

		[Route("details-dropdown/{id}")]
		public IActionResult DetailsDropdown(string id)
		{
			var code = id;

			var nameToChange = cityWeatherList.Where(temp => temp.CityUniqueCode == code).FirstOrDefault();

			return PartialView("_DetailsPartialView", nameToChange);
		}
	}
}
