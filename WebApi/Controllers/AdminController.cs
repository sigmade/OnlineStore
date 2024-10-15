using Microsoft.AspNetCore.Mvc;
using WebApi.ExternalServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IElasticCLient _elasticCLient;

        public AdminController(IElasticCLient elasticCLient)
        {
            _elasticCLient = elasticCLient;
        }

        [HttpGet("RefreshData")]
        public async Task<ActionResult> Upload()
        {
            await _elasticCLient.UpdateDocuments();
            return Ok();
        }
    }
}
