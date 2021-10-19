using Refit;
using System.Threading.Tasks;

namespace API.app360ki_services.Controllers.Weather
{
    public interface IHgWeatherConsultant
    {
        [Get("/weather?woeid={cityCode}")]
        Task<Models.Weather.HgWeather> GetWeather(string cityCode);
    }
}
