using SendApi.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendApi.Service.Services
{
    public class SendDataService : ISendDataService
    {
        private readonly IHttpService _httpService;

        public SendDataService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<string> SendData(string url)
        {
            var result = await _httpService.Get(url);

            return result;
        }
    }
}
