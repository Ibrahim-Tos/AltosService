using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Altos.Domain.Features.Orders;

namespace Altos.Data.Features.Orders
{
    public class OrderCache : IOrderCache
    {
        private readonly OrderTable orderTable;

        public OrderCache()
        {
            orderTable = new OrderTable();
        }

        public Task<Order> Add(Order request)
        {
            var order = orderTable.Add(request);

            return Task.FromResult(order);
        }

        public Task<Order> Update(Order request)
        {
            var order = orderTable.Update(request);

            return Task.FromResult(order);
        }
    }
}
