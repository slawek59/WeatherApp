using Models;
using ServiceContracts;

namespace Services
{
	public class WeatherService : IWeatherService
	{
		private readonly List<CityWeather> _cityWeatherList;

		public WeatherService()
		{

			_cityWeatherList = new List<CityWeather>()
			{
				new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Now.AddHours(-1), TemperatureFahrenheit = 33},

				new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Now.AddHours(-6), TemperatureFahrenheit = 60},

				// this date and time is just for the sake of being here
				new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82},

				new CityWeather() { CityUniqueCode = "GDA", CityName = "Gdańsk", DateAndTime = DateTime.Now, TemperatureFahrenheit = 30},

				new CityWeather() { CityUniqueCode = "WRO", CityName = "Wrocław", DateAndTime = DateTime.Now, TemperatureFahrenheit = 90},

				new CityWeather() { CityUniqueCode = "KRK", CityName = "Kraków", DateAndTime = DateTime.Now, TemperatureFahrenheit = 50}
			};
		}
		public CityWeather? GetWeatherByCityCode(string cityCode)
		{

			CityWeather? city = _cityWeatherList.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();

			return city;

		}

		public List<CityWeather> GetWeatherDetails()
		{
			return _cityWeatherList;
		}
	}
}