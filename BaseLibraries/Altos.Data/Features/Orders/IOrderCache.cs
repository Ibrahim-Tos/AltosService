using System.Threading.Tasks;
using Altos.Domain.Features.Orders;

namespace Altos.Data.Features.Orders
{
    public interface IOrderCache
    {
        Task<Order> Add(Order product);
    }
}
