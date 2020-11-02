using Altos.Domain.Features.Products;
using Altos.Util.Entities;
using FluentValidation.Attributes;

namespace Altos.Services.Features.Products.Dtos
{
    [Validator(typeof(CreateProductCommandValidator))]
    public class CreateProductCommand : ICommand
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public ProductType ProductType { get; set; } = ProductType.InstantiableProduct;
        public string ProductTimeZoneId { get; set; }
        public decimal Price { get; set; }
    }
}
