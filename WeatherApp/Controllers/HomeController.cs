using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		[Route("/")]
		[Route("home")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
