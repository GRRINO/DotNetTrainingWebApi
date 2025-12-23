using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingAPIMVC
{
    public class HttpClientService
    {
        private readonly HttpClient _client;
        public HttpClientService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T>(string url, HttpMethodType method,object data = null)
        {
            var request = new HttpRequestMessage(new HttpMethod(method.ToString());
        }

        public enum HttpMethodType
        {
            Get,
            Post,
            Put,
            Patch,
            Delete
        }
    }
}
