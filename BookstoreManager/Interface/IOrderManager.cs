using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IOrderManager
    {
        string AddOrder(OrderModel orderModel);
    }
}