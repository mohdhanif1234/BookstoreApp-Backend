using BookstoreModels;
using BookstoreRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookstoreRepository.Repository
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly IConfiguration config;
        public string connectionString { get; set; } = "BookstoreAppConnectionString";
        public WishlistRepository(IConfiguration configuration)
        {
            this.config = configuration;
        }
        public string AddToWishlist(WishlistModel wishlistModel)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForCreatingWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", wishlistModel.UserId);
                    cmd.Parameters.AddWithValue("@BookId", wishlistModel.BookId);
                    con.Open();
                    int a = Convert.ToInt32(cmd.ExecuteScalar());
                    if (a == 2)
                    {
                        return "BookId does not exists";
                    }
                    else if (a == 1)
                    {
                        return "Book already added to wishlist";
                    }
                    else
                    {
                        return "Book added to wishlist successfully";
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string DeleteFromWishlist(int wishlistId)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForDeletingBookFromWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WishlistId", wishlistId);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        return "Book deleted from wishlist successfully";
                    }
                    else
                    {
                        return "Book is not present in the wishlist";
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
