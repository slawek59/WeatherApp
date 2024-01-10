using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.ViewComponents
{
	[ViewComponent]
	public class CityViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
		{
			ViewBag.CssClass = GetCssClass(city.TemperatureFahrenheit); 
				
			return View(city);
		}
		private string GetCssClass(int Temperature)
		{
			return Temperature switch
			{
				(< 44) => "blue-back",
				(>= 44) and (< 75) => "green-back",
				(>= 75) => "orange-back",
			};
		}
	}
}
