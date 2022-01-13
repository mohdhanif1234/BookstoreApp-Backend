using BookstoreModels;
using BookstoreRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BookstoreRepository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IConfiguration Configuration { get; }
        public OrderRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        SqlConnection sqlConnection;
        public string AddOrder(OrderModel order)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookstoreAppConnectionString"));
            try
            {
                using (sqlConnection)
                {
                    string storeprocedure = "spForAddingOrders";
                    SqlCommand sqlCommand = new SqlCommand(storeprocedure, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", order.UserId);
                    sqlCommand.Parameters.AddWithValue("@AddressId", order.AddressId);
                    sqlCommand.Parameters.AddWithValue("@BookId", order.BookId);
                    sqlCommand.Parameters.AddWithValue("@BookQuantity", order.Quantity);
                    sqlConnection.Open();
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    if (result == 2)
                    {
                        return "BookId not exists";
                    }
                    else if (result == 1)
                    {
                        return "Userid not exists";
                    }
                    else
                    {
                        return "Ordered successfully";
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<OrderModel> RetrieveOrderDetails(int userId)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookstoreAppConnectionString"));
            try
            {
                using (sqlConnection)
                {
                    string storeprocedure = "spForGettingAllOrderDetailsById";
                    SqlCommand sqlCommand = new SqlCommand(storeprocedure, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlConnection.Open();
                    SqlDataReader sqlData = sqlCommand.ExecuteReader();
                    List<OrderModel> order = new List<OrderModel>();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            OrderModel orderModel = new OrderModel();
                            BookDetailsModel bookModel = new BookDetailsModel();
                            bookModel.BookTitle = sqlData["BookTitle"].ToString();
                            bookModel.AuthorName = sqlData["AuthorName"].ToString();
                            bookModel.DiscountedPrice = Convert.ToInt32(sqlData["DiscountedPrice"]);
                            bookModel.OriginalPrice = Convert.ToInt32(sqlData["OriginalPrice"]);
                            bookModel.Image = sqlData["Image"].ToString();
                            orderModel.OrderId = Convert.ToInt32(sqlData["OrderId"]);
                            //orderModel.OrderDate = sqlData["OrderDate"].ToString();
                            orderModel.bookDetailsModel = bookModel;
                            order.Add(orderModel);
                        }
                        return order;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
