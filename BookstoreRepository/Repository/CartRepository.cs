using BookstoreModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BookstoreRepository.Repository
{
    public class CartRepository : ICartRepository
    {
        public IConfiguration config { get; }
        public string connectionString { get; set; } = "BookstoreAppConnectionString";
        public CartRepository(IConfiguration configuration)
        {
            this.config = configuration;
        }
        public string AddToCart(CartModel cartModel)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spAddingBookToCart", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                    cmd.Parameters.AddWithValue("@UserId", cartModel.UserId);
                    cmd.Parameters.AddWithValue("@QtyToOrder", cartModel.QtyToOrder);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        return "The book is added to the cart successfully";
                    }
                    else
                    {
                        return "The book is not added to the cart";
                    }
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
