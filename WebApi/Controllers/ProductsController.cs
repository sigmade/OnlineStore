using Microsoft.AspNetCore.Mvc;
using WebApi.ExternalServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IElasticCLient _elasticCLient;

        public ProductsController(IElasticCLient elasticCLient)
        {
            _elasticCLient = elasticCLient;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] string query)
        {
            var res = await _elasticCLient.GetProducts(query);
            return Ok(res);
        }
    }
}
