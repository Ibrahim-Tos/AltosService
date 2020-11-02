using System.Linq;
using System.Threading.Tasks;
using Altos.Domain.Features.Products;
using Altos.Services.Features.Products.Dtos;
using Altos.Util.Application.Dto;

namespace Altos.Services.Features.Products
{
    public interface IProductInstanceService
    {
        Task<ProductInstanceDto> Create(CreateProductInstanceCommand createProductCommand);
        Task<ProductInstanceDto> GetAsync(int id);
        Task<PagedList<ProductInstance>> GetAllPagedAsync(GetProductInstancesQuery getQuery);
        ProductInstanceDto Update(UpdateProductInstanceCommand updateProductInstanceCommand);
    }
}
