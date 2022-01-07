using BookstoreModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BookstoreRepository.Repository
{
    public interface ICartRepository
    { 
        string connectionString { get; set; }
        string AddToCart(CartModel cartModel);
        string UpdateBookQuantity(int cartId, int qtyToOrder);
        string DeleteCart(int cartId);
        List<CartModel> GetCartDetails(int userId);
    }
}