using Altos.Api.Framework.Infrastructure.Authorization;
using Altos.Services.Features.Products;
using Altos.Services.Features.Products.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Altos.Api.Features.Products.CreateProduct
{
    /// <summary>
    /// Products controller
    /// </summary>
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Products Controller
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="request">The create product command</param>
        [Authorize]
        [HttpPost]
        [PermissionPolicy(typeof(CreateProductPermissionPolicy))]
        public IActionResult Post([FromBody] CreateProductCommand request)
        {
            var product = _productService.Create(request);

            return Ok(product);
        }
    }
}
