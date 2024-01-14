using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Infrastructure.ExternalService
{
    public interface IAPIService
    {
        Task<string> GetAsync(string endPoint);
        Task<string> PostAsync(string endPoint, object data);
        Task<string> PutAsync(string endPoint, object data);
    }
}
