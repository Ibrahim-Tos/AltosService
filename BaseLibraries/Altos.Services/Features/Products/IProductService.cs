using System.Linq;
using System.Threading.Tasks;
using Altos.Domain.Features.Products;
using Altos.Services.Features.Products.Dtos;
using Altos.Util.Application.Dto;

namespace Altos.Services.Features.Products
{
    public interface IProductService
    {
        Task<ProductDto> Create(CreateProductCommand createProductCommand);
        Task<ProductDto> GetAsync(int id);
        Task<PagedList<Product>> GetAllPagedAsync(GetProductsQuery getQuery);
        ProductDto Update(UpdateProductCommand updateProductCommand);
    }
}
