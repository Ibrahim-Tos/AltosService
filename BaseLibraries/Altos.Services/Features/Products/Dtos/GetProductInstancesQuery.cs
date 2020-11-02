using System;
using System.Collections.Generic;
using Altos.Util.Application.Dto;

namespace Altos.Services.Features.Products.Dtos
{
    public class GetProductInstancesQuery : PagedSortedRequest
    {
        public DateTime StartDateTimeFrom { get; set; }
        public DateTime StartDateTimeTo { get; set; }

        public List<int> ProductIds { get; set; } = new List<int>();

        public bool OnlyBookedInstances { get; set; }
    }
}
