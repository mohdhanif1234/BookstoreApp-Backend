using BookstoreModels;
using Microsoft.Extensions.Configuration;

namespace BookstoreRepository.Interface
{
    public interface IOrderRepository
    {
        IConfiguration Configuration { get; }
        string AddOrder(OrderModel order);
    }
}