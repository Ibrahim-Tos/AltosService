using Altos.Domain.Features.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Altos.Data.Features.Products
{
    public interface IProductInstanceCache
    {
        Task<ProductInstance> Add(ProductInstance productInstance);

        Task<ProductInstance> Update(ProductInstance productInstance);

        Task<ProductInstance> Get(int id);

        Task<IQueryable<ProductInstance>> GetAll();

        Task Delete(ProductInstance productInstance);
    }
}
