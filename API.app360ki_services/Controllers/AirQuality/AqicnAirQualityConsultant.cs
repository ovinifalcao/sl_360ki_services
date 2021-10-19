using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Threading.Tasks;

namespace API.app360ki_services.Controllers.AirQuality
{
    [Route("api/[controller]")]
    [ApiController]
    public class AqicnAirQualityConsultant : ControllerBase
    {
        [HttpGet]
        public async Task<Models.AirQuality.AqicnData> GetAirQualityInfo()
        {
            var AirQuality = RestService.For<IAqicnAirQualityConsultant>("https://api.waqi.info");
            return await AirQuality.GetAirQuality(-23.661852, -46.765892);
        }
    }
}


