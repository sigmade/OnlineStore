using System.Net.Http.Headers;
using System.Text;

namespace WebApi.ExternalServices
{
    public interface IElasticCLient
    {
        Task GetProducts();
    }

    public class ElasticCLient : IElasticCLient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ElasticCLient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Elastic");
            var byteArray = Encoding.ASCII.GetBytes("elastic:3NPd35n=gVQ0uRU-1yqc");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            using var body = new StringContent("requstJson", Encoding.UTF8, "application/json");
            using var message = new HttpRequestMessage(HttpMethod.Put, "/product3")
            {
                //Content = body
            };

            using var response = await client.SendAsync(message);
            using var content = response.Content;
            var result = await content.ReadAsStringAsync();
        }
    }
}
