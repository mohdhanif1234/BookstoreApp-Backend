﻿using BookstoreModels;
using Microsoft.Extensions.Configuration;

namespace BookstoreRepository.Repository
{
    public interface ICartRepository
    { 
        string connectionString { get; set; }
        string AddToCart(CartModel cartModel);
    }
}