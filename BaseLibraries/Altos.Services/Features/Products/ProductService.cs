using System;
using System.Threading.Tasks;
using Altos.Data.Features.Products;
using Altos.Domain.Features.Products;
using Altos.Services.Features.Products.Dtos;
using Altos.Util.Application.Dto;
using AutoMapper;

namespace Altos.Services.Features.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductCache productCache;

        public ProductService(IMapper mapper, IProductCache productCache)
        {
            this.mapper = mapper;
            this.productCache = productCache;
        }

        public async Task<ProductDto> Create(CreateProductCommand command)
        {
            var product = new Product
            {
                Title = command.Title,
                SubTitle = command.SubTitle,
                ShortDescription = command.ShortDescription,
                FullDescription = command.FullDescription,
                ProductType = command.ProductType,
                ProductTimeZoneId = command.ProductTimeZoneId,
                StockQuantity = 0,
                Price = command.Price
            };

            await productCache.Add(product);

            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await productCache.Get(id);

            return mapper.Map<ProductDto>(product);
        }

        public async Task<PagedList<Product>> GetAllPagedAsync(GetProductsQuery getQuery)
        {
            var queryable = await productCache.GetAll();

            var productPagedList = new PagedList<Product>(queryable, getQuery.PageIndex, getQuery.PageSize, false);
            
            return productPagedList;
        }

        public ProductDto Update(UpdateProductCommand updateProductCommand)
        {
            throw new NotImplementedException();
        }
    }
}
