using Refit;
using System.Threading.Tasks;

namespace API.app360ki_services.Controllers.AirQuality
{
    public interface IAqicnAirQualityConsultant
    {
            [Get("/feed/geo:{lat};{log}/?token=55ebeb4918695c998ae7cb113a8961bed2deddba")]
            Task<Models.AirQuality.AqicnData> GetAirQuality(double lat, double log);
    }
}
