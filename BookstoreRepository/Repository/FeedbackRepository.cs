using BookstoreModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BookstoreRepository.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public IConfiguration Configuration { get; }
        public FeedbackRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        SqlConnection sqlConnection;
        public string AddFeedback(FeedbackModel feedback)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookstoreAppConnectionString"));
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spForAddingReviews", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Rating", feedback.Ratings);
                    sqlCommand.Parameters.AddWithValue("@Comment", feedback.Comments);
                    sqlCommand.Parameters.AddWithValue("@BookId", feedback.BookId);
                    sqlCommand.Parameters.AddWithValue("@UserId", feedback.UserId);
                    sqlConnection.Open();
                    int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    if (result == 2)
                    {
                        return "BookId not exists";
                    }
                    else if (result == 1)
                    {
                        return "Already given Feedback for this book";
                    }
                    else
                    {
                        return "Feedback added successfully";
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
    }
}
