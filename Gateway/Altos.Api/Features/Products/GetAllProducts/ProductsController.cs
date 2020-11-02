using System;
using System.Threading.Tasks;
using Altos.Services.Features.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Altos.Api.Features.Products.GetAllProducts
{
    //[ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <remarks>This API will get the products.</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("api/products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                

                return Ok("Products List");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
