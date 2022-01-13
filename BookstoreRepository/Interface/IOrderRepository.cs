using BookstoreModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BookstoreRepository.Interface
{
    public interface IOrderRepository
    {
        IConfiguration Configuration { get; }
        string AddOrder(OrderModel order);
        List<OrderModel> RetrieveOrderDetails(int userId);
    }
}