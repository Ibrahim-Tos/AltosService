using Altos.Domain.Features.Products;
using FluentValidation;

namespace Altos.Services.Features.Products.Dtos
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            this.RuleFor(x => x)
                .NotNull()
                .WithErrorCode("command_is_null")
                .WithMessage("Command must be set");

            this.RuleFor(x => x.Title)
                .NotNull()
                .WithErrorCode("title_is_null")
                .WithMessage("title must be set");

            this.RuleFor(x => x.ProductTimeZoneId)
                .NotNull()
                .When(x => x.ProductType == ProductType.InstantiableProduct)
                .WithErrorCode("timeZoneId_is_null")
                .WithMessage("Time zone must be set for this kind of products");
        }
    }
}
