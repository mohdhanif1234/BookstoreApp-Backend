using BookstoreManager.Interface;
using BookstoreModels;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManager.Manager
{
    public class WishlistManager : IWishlistManager
    {
        private readonly IWishlistRepository wishlistRepository;
        public WishlistManager(IWishlistRepository wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }
        public string AddToWishlist(WishlistModel wishlistModel)
        {
            try
            {
                return this.wishlistRepository.AddToWishlist(wishlistModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
