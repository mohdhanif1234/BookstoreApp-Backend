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
    public class BooksRepository : IBooksRepository
    {
        private readonly IConfiguration config;
        public string connectionString { get; set; } = "BookstoreAppConnectionString";
        public BooksRepository(IConfiguration configuration)
        {
            this.config = configuration;
        }
        public string AddBookDetails(BookDetailsModel bookDetailsModel)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForAddingBookDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookTitle", bookDetailsModel.BookTitle);
                    cmd.Parameters.AddWithValue("@AuthorName", bookDetailsModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookDetailsModel.Rating);
                    cmd.Parameters.AddWithValue("@RatingCount", bookDetailsModel.RatingCount);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookDetailsModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@DiscountedPrice", bookDetailsModel.DiscountedPrice);
                    cmd.Parameters.AddWithValue("@Description", bookDetailsModel.Description);
                    cmd.Parameters.AddWithValue("@BookQty", bookDetailsModel.BookQty);
                    cmd.Parameters.AddWithValue("@Image", bookDetailsModel.Image);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        con.Close();
                        return "Book details added successfully";
                    }
                }
                return "Books details addition is unsuccessful";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string DeleteBookDetails(int bookId)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForDeletingBookDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        con.Close();
                        return "Book details deleted successfully";
                    }
                }
                return "Books details deletion is unsuccessful";
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string UpdateBookDetails(BookDetailsModel bookDetailsModel)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForUpdatingBookDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookDetailsModel.BookId);
                    cmd.Parameters.AddWithValue("@Rating", bookDetailsModel.Rating);
                    cmd.Parameters.AddWithValue("@RatingCount", bookDetailsModel.RatingCount);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookDetailsModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@DiscountedPrice", bookDetailsModel.DiscountedPrice);
                    cmd.Parameters.AddWithValue("@Description", bookDetailsModel.Description);
                    cmd.Parameters.AddWithValue("@BookQty", bookDetailsModel.BookQty);
                    cmd.Parameters.AddWithValue("@Image", bookDetailsModel.Image);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        con.Close();
                        return "Book details updated successfully";
                    }
                }
                return "Book details updation is unsuccessful";
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<BookDetailsModel> GetBookDetailsById(int bookId)
        {
            try
            {
                List<BookDetailsModel> allBooksList = new List<BookDetailsModel>();
                BookDetailsModel bookDetailsModel = new BookDetailsModel();
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForGettingSingleBookDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            bookDetailsModel.BookId = Convert.ToInt32(dr["BookId"]);
                            bookDetailsModel.BookTitle = dr["BookTitle"].ToString();
                            bookDetailsModel.AuthorName = dr["AuthorName"].ToString();
                            bookDetailsModel.Rating = Convert.ToInt32(dr["Rating"]);
                            bookDetailsModel.RatingCount = Convert.ToInt32(dr["RatingCount"]);
                            bookDetailsModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                            bookDetailsModel.DiscountedPrice = Convert.ToInt32(dr["DiscountedPrice"]);
                            bookDetailsModel.Description = dr["Description"].ToString();
                            bookDetailsModel.BookQty = Convert.ToInt32(dr["BookQty"]);
                            bookDetailsModel.Image = dr["Image"].ToString();
                            allBooksList.Add(bookDetailsModel);
                        }
                        return allBooksList;
                    }
                    else
                    {
                        con.Close();
                        return null;
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
