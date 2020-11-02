using System.Collections.Concurrent;
using Altos.Domain.Features.Orders;

namespace Altos.Data.Features.Orders
{
    public class OrderTable
    {
        private readonly ConcurrentDictionary<int, Order> orderTable = new ConcurrentDictionary<int, Order>();

        public Order Add(Order order)
        {
            order.Id = orderTable.Values.Count + 1;
            orderTable[order.Id] = order;

            return orderTable[order.Id];
        }

        public Order Update(Order order)
        {
            orderTable[order.Id] = order;

            return orderTable[order.Id];
        }
    }
}
