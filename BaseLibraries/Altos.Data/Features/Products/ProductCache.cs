using System.Linq;
using System.Threading.Tasks;
using Altos.Domain.Features.Products;

namespace Altos.Data.Features.Products
{
    public class ProductCache : IProductCache
    {
        private readonly ProductTable productTable;

        public ProductCache()
        {
            productTable = ProductTable.Instance;
        }

        public Task<Product> Add(Product request)
        {
            var product = productTable.Add(request);

            return Task.FromResult(product);
        }

        public Task<Product> Update(Product request)
        {
            var product = productTable.Update(request);

            return Task.FromResult(product);
        }

        public Task<Product> Get(int id)
        {
            var product = productTable.Get(id);

            return Task.FromResult(product);
        }

        public Task<IQueryable<Product>> GetAll()
        {
            var products = productTable.GetAll();

            return Task.FromResult(products);
        }

        public Task Delete(Product product)
        {
            productTable.Delete(product.Id);

            return Task.FromResult(0);
        }
    }
}
