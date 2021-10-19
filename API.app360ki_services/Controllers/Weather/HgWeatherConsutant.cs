using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace API.app360ki_services.Controllers.Weather
{
    [Route("api/[controller]")]
    [ApiController]
    public class HgWeatherConsutant : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Models.Weather.HgWeather>> GetHgWhather()
        {
            var Weather = RestService.For<IHgWeatherConsultant>("https://api.hgbrasil.com");
            return await Weather.GetWeather("455827");
        }
    }
}
