using System.Threading.Tasks;
using Altos.Domain.Features.Orders;

namespace Altos.Data.Features.Orders
{
    public class OrderItemCache : IOrderItemCache
    {
        private readonly OrderItemTable orderItemTable;

        public OrderItemCache()
        {
            orderItemTable = new OrderItemTable();
        }

        public Task<OrderItem> Add(OrderItem request)
        {
            var orderItem = orderItemTable.Add(request);

            return Task.FromResult(orderItem);
        }

        public Task<OrderItem> Update(OrderItem request)
        {
            var orderItem = orderItemTable.Update(request);

            return Task.FromResult(orderItem);
        }
    }
}
