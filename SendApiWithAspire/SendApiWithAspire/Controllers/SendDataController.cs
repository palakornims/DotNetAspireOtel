using Microsoft.AspNetCore.Mvc;
using SendApi.Service.IServices;

namespace SendApiWithAspire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendDataController : ControllerBase
    {
        private readonly ISendDataService _sendDataService;
        
        public SendDataController(ISendDataService sendDataService)
        {
            _sendDataService = sendDataService;
        }

        [HttpPost("SendData")]
        public async Task<IActionResult> SendData(string url)
        {
            return Ok(await _sendDataService.SendData(url));
        }
    }
}
