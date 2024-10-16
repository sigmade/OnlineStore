﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetProducts()
        {
            await _elasticCLient.GetProducts();
            return Ok();
        }
    }
}
