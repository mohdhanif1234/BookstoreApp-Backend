using BookstoreModels;

namespace BookstoreRepository.Interface
{
    public interface IWishlistRepository
    {
        string connectionString { get; set; }
        string AddToWishlist(WishlistModel wishlistModel);
        string DeleteFromWishlist(int wishlistId);
    }
}