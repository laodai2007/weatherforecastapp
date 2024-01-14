using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.ExternalService;

namespace WeatherApp.Infrastructure
{
    public class WeatherInfoAPIRepository : IWeatherInfoAPIRepository
    {
        private const string API_URL = "http://api.weatherstack.com/current?access_key=a24a5662854b835aaf6c03f17a3dcb1a&query=";
        private readonly IAPIService _apiService;

        public WeatherInfoAPIRepository(IAPIService apiService)
        {
            _apiService = apiService;
        }
        public async Task<WeatherInfoDTO> GetWeatherInfo(string zipcode)
        {
            string apiUrl = API_URL + zipcode;

            //Call external service 
            var result = await _apiService.GetAsync(apiUrl);
            if (result != null)
            {
                var weatherApiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherInfo>(result);
                if (weatherApiResponse?.Location != null)
                {
                    var weatherModel = new WeatherInfoDTO
                    {
                        LocationName = weatherApiResponse.Location.Name,
                        UVIndex = weatherApiResponse.Current.Uv_index,
                        WindSpeed = weatherApiResponse.Current.Wind_speed,
                        WeatherDescriptions = weatherApiResponse.Current.Weather_descriptions
                    };
                    return weatherModel;
                }
                return null;
            }
            return null;
        }
    }
}
