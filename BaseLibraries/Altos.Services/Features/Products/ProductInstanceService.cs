using System;
using System.Threading.Tasks;
using Altos.Data.Features.Products;
using Altos.Domain.Features.Products;
using Altos.Services.Features.Products.Dtos;
using Altos.Util.Application.Dto;
using AutoMapper;

namespace Altos.Services.Features.Products
{
    public class ProductInstanceService : IProductInstanceService
    {
        private readonly IMapper mapper;
        private readonly IProductInstanceCache productInstanceCache;

        public ProductInstanceService(IMapper mapper, IProductInstanceCache productInstanceCache)
        {
            this.mapper = mapper;
            this.productInstanceCache = productInstanceCache;
        }

        public async Task<ProductInstanceDto> Create(CreateProductInstanceCommand command)
        {
            var productInstance = new ProductInstance
            {
                Title = command.Title
            };

            await productInstanceCache.Add(productInstance);

            return mapper.Map<ProductInstanceDto>(productInstance);
        }

        public async Task<ProductInstanceDto> GetAsync(int id)
        {
            var productInstance = await productInstanceCache.Get(id);

            return mapper.Map<ProductInstanceDto>(productInstance);
        }

        public async Task<PagedList<ProductInstance>> GetAllPagedAsync(GetProductInstancesQuery getQuery)
        {
            var queryable = await productInstanceCache.GetAll();

            var productInstancePagedList = new PagedList<ProductInstance>(queryable, getQuery.PageIndex, getQuery.PageSize, false);

            return productInstancePagedList;
        }

        public ProductInstanceDto Update(UpdateProductInstanceCommand updateProductInstanceCommand)
        {
            throw new NotImplementedException();
        }
    }
}
