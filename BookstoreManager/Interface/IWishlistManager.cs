using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreManager.Interface
{
    public interface IWishlistManager
    {
        string AddToWishlist(WishlistModel wishlistModel);
        string DeleteFromWishlist(int wishlistId);
        List<WishlistModel> GetWishlistDetailsByUserId(int userId);
    }
}