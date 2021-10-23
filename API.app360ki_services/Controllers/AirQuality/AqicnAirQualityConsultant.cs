using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace API.app360ki_services.Controllers.AirQuality
{
    [Route("api/[controller]")]
    [ApiController]
    public class AqicnAirQualityConsultant : ControllerBase
    {
        [HttpGet("{lat},{lgt}")]
        public async Task<Models.AirQuality.AqicnData> GetAirQualityInfo(double lat, double lgt)
        {
            var AirQuality = RestService.For<IAqicnAirQualityConsultant>("https://api.waqi.info");
            return await AirQuality.GetAirQuality(lat, lgt);
        }
    }
}


