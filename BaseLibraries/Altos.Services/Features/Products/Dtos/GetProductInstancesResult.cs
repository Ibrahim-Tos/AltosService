using System.Collections.Generic;
using Altos.Util.Application.Dto;

namespace Altos.Services.Features.Products.Dtos
{
    public class GetProductInstancesResult : PagedResponse
    {
        public List<ProductInstanceDto> Items { get; set; }
    }
}
