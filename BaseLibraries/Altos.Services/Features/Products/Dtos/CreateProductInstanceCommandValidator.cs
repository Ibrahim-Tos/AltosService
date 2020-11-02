using FluentValidation;

namespace Altos.Services.Features.Products.Dtos
{
    public class CreateProductInstanceCommandValidator : AbstractValidator<CreateProductInstanceCommand>
    {
        public CreateProductInstanceCommandValidator()
        {
            this.RuleFor(x => x)
                .NotNull()
                .WithErrorCode("command_is_null")
                .WithMessage("Command must be set");

            this.RuleFor(x => x.Title)
                .NotNull()
                .WithErrorCode("title_is_null")
                .WithMessage("title must be set");

            this.RuleFor(x => x.StartDateTime)
                .NotNull()
                .WithErrorCode("start_date_is_null")
                .WithMessage("Start DateTime must be set");

            this.RuleFor(x => x.ProductId)
                .NotEqual(0)
                .NotNull()
                .WithErrorCode("productId_is_null")
                .WithMessage("Product id must be set");
        }
    }
}
