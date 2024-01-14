using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Infrastructure.ExternalService;

namespace WeatherApp.Infrastructure
{
    public class APIService : IAPIService
    {
        public APIService()
        {
        }

        private async Task<HttpResponseMessage> SendAsync(HttpMethod method, string endPoint, object data = null)
        {
            try
            {
                using var httpClient = new HttpClient();
                var request = new HttpRequestMessage(method, endPoint);
                if (data != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                }

                return await httpClient.SendAsync(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetAsync(string endpoint)
        {
            var response = await SendAsync(HttpMethod.Get, endpoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        public async Task<string> PostAsync(string endpoint, object data)
        {
            var response = await SendAsync(HttpMethod.Post, endpoint, data);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PutAsync(string endpoint, object data)
        {
            var response = await SendAsync(HttpMethod.Put, endpoint, data);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
