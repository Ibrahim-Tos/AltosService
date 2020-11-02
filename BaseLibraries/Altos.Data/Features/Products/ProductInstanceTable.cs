using System;
using System.Collections.Concurrent;
using System.Linq;
using Altos.Domain.Features.Products;

namespace Altos.Data.Features.Products
{
    public class ProductInstanceTable
    {
        private readonly ConcurrentDictionary<int, ProductInstance> productInstanceTable = new ConcurrentDictionary<int, ProductInstance>();

        private static ProductInstanceTable instance = null;
        private static readonly object padlock = new object();

        private ProductInstanceTable()
        {
        }

        public static ProductInstanceTable Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ProductInstanceTable();
                    }
                    return instance;
                }
            }
        }

        public ProductInstance Add(ProductInstance productInstance)
        {
            productInstance.Id = productInstanceTable.Values.Count + 1;
            productInstanceTable[productInstance.Id] = productInstance;

            return productInstanceTable[productInstance.Id];
        }

        public ProductInstance Update(ProductInstance productInstance)
        {
            productInstanceTable[productInstance.Id] = productInstance;

            return productInstanceTable[productInstance.Id];
        }

        public ProductInstance Get(int id)
        {
            if (productInstanceTable.TryGetValue(id, out ProductInstance productInstance))
            {
                return productInstance;
            }
            throw new Exception("ProductInstance not found");
        }

        public IQueryable<ProductInstance> GetAll()
        {
            var products = productInstanceTable.Values;

            return products.AsQueryable();
        }

        public void Delete(int id)
        {
            if (!productInstanceTable.TryRemove(id, out ProductInstance productInstance))
            {
                throw new Exception($"ProductInstance with id {productInstance.Id} not deleted");
            }
        }
    }
}
