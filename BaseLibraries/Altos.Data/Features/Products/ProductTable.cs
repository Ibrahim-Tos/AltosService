using System;
using System.Collections.Concurrent;
using System.Linq;
using Altos.Domain.Features.Products;

namespace Altos.Data.Features.Products
{
    public class ProductTable
    {
        private readonly ConcurrentDictionary<int, Product> productTable = new ConcurrentDictionary<int, Product>();

        private static ProductTable instance = null;
        private static readonly object padlock = new object();

        private ProductTable()
        {
        }

        public static ProductTable Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ProductTable();
                    }
                    return instance;
                }
            }
        }

        public Product Add(Product product)
        {
            product.Id = productTable.Values.Count + 1;
            productTable[product.Id] = product;

            return productTable[product.Id];
        }

        public Product Update(Product product)
        {
            productTable[product.Id] = product;

            return productTable[product.Id];
        }

        public Product Get(int id)
        {
            if (productTable.TryGetValue(id, out Product product))
            {
                return product;
            }
            throw new Exception("Product not found");
        }

        public IQueryable<Product> GetAll()
        {
            var products = productTable.Values;

            return products.AsQueryable();
        }

        public void Delete(int id)
        {
            if (!productTable.TryRemove(id, out Product product))
            {
                throw new Exception($"Product with id {product.Id} not deleted");
            }
        }
    }
}
