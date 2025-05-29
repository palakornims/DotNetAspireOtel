using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendApi.Service.IServices
{
    public interface ISendDataService
    {
        Task<string> SendData(string url);
    }
}
