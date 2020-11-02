using Altos.Domain.Features.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Altos.Data.Features.Products
{
    public interface IProductCache
    {
        Task<Product> Add(Product product);

        Task<Product> Update(Product product);

        Task<Product> Get(int id);

        Task<IQueryable<Product>> GetAll();

        Task Delete(Product product);
    }
}
