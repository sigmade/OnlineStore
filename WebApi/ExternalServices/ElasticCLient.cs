using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WebApi.Products;

namespace WebApi.ExternalServices;

public interface IElasticCLient
{
    Task<Rootobject?> GetProducts();
    Task UpdateDocuments();
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

    public async Task<Rootobject?> GetProducts()
    {
        var client = _httpClientFactory.CreateClient("Elastic");
        var byteArray = Encoding.ASCII.GetBytes("elastic:3mMK*Sr-wvzcANKJv*eN");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

        var requestString = "{\"query\": {\"match\": {\"description\": \"Флагманское\"}}}";

        using var body = new StringContent(requestString, Encoding.UTF8, "application/json");
        using var message = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, "/products/_search")
        {
            Content = body
        };

        using var response = await client.SendAsync(message);
        using var content = response.Content;
        var result = await content.ReadAsStringAsync();

        var res = JsonSerializer.Deserialize<Rootobject>(result);
        return res;
    }

    public async Task UpdateDocuments()
    {
        var res = await _client.BulkAsync(b => b
            .Index("products")
            .IndexMany(Product.InitializeProductList())
        );
    }
}


public class Rootobject
{
    public int took { get; set; }
    public bool timed_out { get; set; }
    public _Shards _shards { get; set; }
    public Hits hits { get; set; }
}

public class _Shards
{
    public int total { get; set; }
    public int successful { get; set; }
    public int skipped { get; set; }
    public int failed { get; set; }
}

public class Hits
{
    public Total total { get; set; }
    public float max_score { get; set; }
    public Hit[] hits { get; set; }
}

public class Total
{
    public int value { get; set; }
    public string relation { get; set; }
}

public class Hit
{
    public string _index { get; set; }
    public string _id { get; set; }
    public float _score { get; set; }
    public _Source _source { get; set; }
}

public class _Source
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int price { get; set; }
}

