using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface ICartManager
    {
        string AddToCart(CartModel cartModel);
    }
}