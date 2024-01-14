using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Application
{
    public class WeatherInfoService
    {
        private readonly IWeatherInfoAPIRepository _weatherInfoRepository;
        public WeatherInfoService(IWeatherInfoAPIRepository weatherInfoRepository)
        {
            _weatherInfoRepository = weatherInfoRepository;
        }

        public async Task<WeatherInfoDTO> GetWeatherInfos(string url)
        {
            var result = await _weatherInfoRepository.GetWeatherInfo(url);
            return result;
        }
    }
}
