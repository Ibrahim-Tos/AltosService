using System.Collections.Concurrent;
using Altos.Domain.Features.Orders;

namespace Altos.Data.Features.Orders
{
    public class OrderItemTable
    {
        private readonly ConcurrentDictionary<int, OrderItem> orderItemTable = new ConcurrentDictionary<int, OrderItem>();

        public OrderItem Add(OrderItem orderItem)
        {
            orderItem.Id = orderItemTable.Values.Count + 1;
            orderItemTable[orderItem.Id] = orderItem;

            return orderItemTable[orderItem.Id];
        }

        public OrderItem Update(OrderItem orderItem)
        {
            orderItemTable[orderItem.Id] = orderItem;

            return orderItemTable[orderItem.Id];
        }
    }
}
