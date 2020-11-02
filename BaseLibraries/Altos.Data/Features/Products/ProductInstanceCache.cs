using System.Linq;
using System.Threading.Tasks;
using Altos.Domain.Features.Products;

namespace Altos.Data.Features.Products
{
    public class ProductInstanceCache : IProductInstanceCache
    {
        private readonly ProductInstanceTable productInstanceTable;

        public ProductInstanceCache()
        {
            productInstanceTable = ProductInstanceTable.Instance;
        }

        public Task<ProductInstance> Add(ProductInstance request)
        {
            var productInstance = productInstanceTable.Add(request);

            return Task.FromResult(productInstance);
        }

        public Task<ProductInstance> Update(ProductInstance request)
        {
            var productInstance = productInstanceTable.Update(request);

            return Task.FromResult(productInstance);
        }

        public Task<ProductInstance> Get(int id)
        {
            var productInstance = productInstanceTable.Get(id);

            return Task.FromResult(productInstance);
        }

        public Task<IQueryable<ProductInstance>> GetAll()
        {
            var productInstances = productInstanceTable.GetAll();

            return Task.FromResult(productInstances);
        }

        public Task Delete(ProductInstance productInstance)
        {
            productInstanceTable.Delete(productInstance.Id);

            return Task.FromResult(0);
        }
    }
}
