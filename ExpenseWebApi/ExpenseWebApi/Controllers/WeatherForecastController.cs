using Microsoft.AspNetCore.Mvc;

namespace ExpenseWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> collectonofWeatherForecast = new List<WeatherForecast>();
            collectonofWeatherForecast.Add(new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary="Very cool"      
            });
            return collectonofWeatherForecast;
        }
    }
}