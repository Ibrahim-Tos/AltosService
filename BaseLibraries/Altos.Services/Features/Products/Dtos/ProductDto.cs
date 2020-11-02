using Altos.Domain.Features.Products;
using Altos.Util.Application.Dto;
using AutoMapper;

namespace Altos.Services.Features.Products.Dtos
{
    [AutoMap(typeof(Product))]
    public class ProductDto : EntityDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string MetaKeywords { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductTimeZoneId { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Title}";
        }
    }
}
