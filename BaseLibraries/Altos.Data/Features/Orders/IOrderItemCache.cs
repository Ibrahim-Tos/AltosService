using System.Threading.Tasks;
using Altos.Domain.Features.Orders;

namespace Altos.Data.Features.Orders
{
    public interface IOrderItemCache
    {
        Task<OrderItem> Add(OrderItem orderItem);
    }
}
