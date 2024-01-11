using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IWeatherService _weatherService;
		public HomeController(IWeatherService weatherService)
		{
			_weatherService = weatherService;
		}

		[Route("/")]
		[Route("home")]
		public IActionResult Index()
		{
			var cityWeatherList = _weatherService.GetWeatherDetails();

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

			var city = _weatherService.GetWeatherByCityCode(cityCode);

			if (city == null)
			{
				HttpContext.Response.StatusCode = 404;
				return View("ErrorPage");
			}

			return View(city);
		}

		[Route("details-dropdown/{id}")]
		public IActionResult DetailsDropdown()
		{
			string cityCode = HttpContext.Request.RouteValues["id"].ToString();

			if (string.IsNullOrEmpty(cityCode))
			{
				HttpContext.Response.StatusCode = 404;
				return View("ErrorPage");
			}

			//var nameToChange = cityWeatherList.Where(temp => temp.CityUniqueCode == code).FirstOrDefault();

			var city = _weatherService.GetWeatherByCityCode(cityCode);

			return PartialView("_DetailsPartialView", city);
		}
	}
}
