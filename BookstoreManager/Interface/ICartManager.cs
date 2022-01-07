using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreManager.Interface
{
    public interface ICartManager
    {
        string AddToCart(CartModel cartModel);
        string UpdateBookQuantity(int cartId, int qtyToOrder);
        string DeleteCart(int cartId);
        List<CartModel> GetCartDetails(int userId);
    }
}