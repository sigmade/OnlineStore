using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System.Net.Http.Headers;
using System.Text;
using WebApi.Products;

namespace WebApi.ExternalServices
{
    public interface IElasticCLient
    {
        Task GetProducts();
    }

    public class ElasticCLient : IElasticCLient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ElasticsearchClient _client;

        public ElasticCLient(IHttpClientFactory httpClientFactory)
        {
            var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
            .CertificateFingerprint("c060786689dbbcfcc28c3d5c2cf1fd74a2574c87e91a3f50a10ae2eab4134aa2")
            .Authentication(new BasicAuthentication("elastic", "3mMK*Sr-wvzcANKJv*eN"));

            _client = new ElasticsearchClient(settings);
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Elastic");
            var byteArray = Encoding.ASCII.GetBytes("elastic:3NPd35n=gVQ0uRU-1yqc");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            using var body = new StringContent("requstJson", Encoding.UTF8, "application/json");
            using var message = new HttpRequestMessage(System.Net.Http.HttpMethod.Put, "/product3")
            {
                //Content = body
            };
        }

        public async Task UpdateDocuments()
        {
            var res = await _client.BulkAsync(b => b
                .Index("products")
                .IndexMany(Product.InitializeProductList())
            );
        }
    }
}
