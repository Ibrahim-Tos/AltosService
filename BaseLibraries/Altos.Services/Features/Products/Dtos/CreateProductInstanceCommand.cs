using FluentValidation.Attributes;
using System;
using Altos.Util.Entities;

namespace Altos.Services.Features.Products.Dtos
{
    [Validator(typeof(CreateProductCommandValidator))]
    public class CreateProductInstanceCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int InitialAvailability { get; set; }
        public int ProductId { get; set; }
    }
}
