using System.Collections.Generic;
using Altos.Util.Application.Dto;

namespace Altos.Services.Features.Products.Dtos
{
    public class GetProductsQuery : PagedSortedRequest
    {
        public List<int> ProductIds { get; set; } = new List<int>();
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
