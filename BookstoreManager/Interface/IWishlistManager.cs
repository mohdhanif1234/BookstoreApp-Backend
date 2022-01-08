using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IWishlistManager
    {
        string AddToWishlist(WishlistModel wishlistModel);
        string DeleteFromWishlist(int wishlistId);
    }
}