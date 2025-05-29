using SendApi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SendApi.Service.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Get(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
