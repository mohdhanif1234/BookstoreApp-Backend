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
        public List<FeedbackModel> RetrieveOrderDetails(int bookId)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookstoreAppConnectionString"));
            try
            {
                using (sqlConnection)
                {
                    string storeprocedure = "spForGettingAllReviewsByBookId";
                    SqlCommand sqlCommand = new SqlCommand(storeprocedure, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BookId", bookId);
                    sqlConnection.Open();
                    SqlDataReader sqlData = sqlCommand.ExecuteReader();
                    List<FeedbackModel> feedback = new List<FeedbackModel>();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            FeedbackModel feedbackModel = new FeedbackModel();
                            RegisterModel user = new RegisterModel();
                            user.FullName = sqlData["FullName"].ToString();
                            feedbackModel.Comments = sqlData["Comment"].ToString();
                            feedbackModel.Ratings = Convert.ToInt32(sqlData["Rating"]);
                            feedbackModel.UserId = Convert.ToInt32(sqlData["UserId"]);
                            feedbackModel.User = user;
                            feedback.Add(feedbackModel);
                        }
                        return feedback;
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
