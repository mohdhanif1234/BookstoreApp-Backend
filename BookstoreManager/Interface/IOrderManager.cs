using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreManager.Interface
{
    public interface IOrderManager
    {
        string AddOrder(OrderModel orderModel);
        List<OrderModel> RetrieveOrderDetails(int userId);
    }
}