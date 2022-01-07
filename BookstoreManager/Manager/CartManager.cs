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
        public string UpdateBookQuantity(int cartId, int qtyToOrder)
        {
            try
            {
                return this.cartRepository.UpdateBookQuantity(cartId, qtyToOrder);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string DeleteCart(int cartId)
        {
            try
            {
                return this.cartRepository.DeleteCart(cartId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<CartModel> GetCartDetails(int userId)
        {
            try
            {
                return this.cartRepository.GetCartDetails(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
