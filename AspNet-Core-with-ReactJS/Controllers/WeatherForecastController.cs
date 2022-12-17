using AspNet_Core_with_ReactJS.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_Core_with_ReactJS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DatabaseContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _context.WeatherForecast;
        }

        [HttpPost]
        [Route("addWeatherForecast")]
        public void AddWeatherForecast(WeatherForecast addItem)
        {
            _context.WeatherForecast.Add(addItem);
            _context.SaveChanges();
        }

        [HttpPost]
        [Route("updateWeatherForecast")]
        public void Update(WeatherForecast updateItem)
        {
            var persistedEntity = _context.WeatherForecast.Find(updateItem.WeatherForecastId);
            if (persistedEntity == null)
            {
                throw new BadHttpRequestException($"Can not found item {updateItem.WeatherForecastId}");
            }
            
            _context.WeatherForecast.Update(persistedEntity);
            _context.SaveChanges();
        }

        [HttpDelete]
        [Route("deleteWeatherForecast/{id}")]
        public void Delete([FromQuery]int id)
        {
            var selectedItem = _context.WeatherForecast.Find(id);
            if (selectedItem == null)
            {
                throw new BadHttpRequestException($"Can not found item {id}");
            }
            _context.WeatherForecast.Remove(selectedItem);
            _context.SaveChanges();
        }
    }
}