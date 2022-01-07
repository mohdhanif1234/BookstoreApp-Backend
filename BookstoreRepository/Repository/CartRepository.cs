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
                    SqlCommand sqlCommand = new SqlCommand("spAddingBookToCart", con);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BookId", cartModel.BookId);
                    sqlCommand.Parameters.AddWithValue("@UserId", cartModel.UserId);
                    sqlCommand.Parameters.AddWithValue("@QtyToOrder", cartModel.QtyToOrder);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    return "The book is added to the cart successfully";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
