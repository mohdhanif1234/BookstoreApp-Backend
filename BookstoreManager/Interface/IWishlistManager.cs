using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IWishlistManager
    {
        string AddToWishlist(WishlistModel wishlistModel);
    }
}