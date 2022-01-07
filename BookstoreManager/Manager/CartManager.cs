using BookstoreManager.Interface;
using BookstoreModels;
using BookstoreRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManager.Manager
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public string AddToCart(CartModel cartModel)
        {
            try
            {
                return this.cartRepository.AddToCart(cartModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
