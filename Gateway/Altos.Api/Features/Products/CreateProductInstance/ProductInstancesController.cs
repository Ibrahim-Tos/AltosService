using Altos.Api.Framework.Infrastructure.Authorization;
using Altos.Services.Features.Products;
using Altos.Services.Features.Products.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Altos.Api.Features.Products.CreateProductInstance
{
    /// <summary>
    /// Products controller
    /// </summary>
    [Route("api/products/{productId}/instances")]
    [ApiController]
    public class ProductInstancesController : ControllerBase
    {
        private readonly IProductInstanceService _productInstanceService;

        /// <summary>
        /// Product Instances Controller
        /// </summary>
        /// <param name="productInstanceService"></param>
        public ProductInstancesController(IProductInstanceService productInstanceService)
        {
            _productInstanceService = productInstanceService;
        }

        /// <summary>
        /// Create a product instance
        /// </summary>
        /// <param name="request">The create product instance command</param>
        [Authorize]
        [HttpPost]
        [PermissionPolicy(typeof(CreateProductInstancePermissionPolicy))]
        public IActionResult Post([FromBody] CreateProductInstanceCommand request)
        {
            var product = _productInstanceService.Create(request);

            return Ok(product);
        }
    }
}
