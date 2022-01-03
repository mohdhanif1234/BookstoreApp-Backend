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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration config;
        public string connectionString { get; set; } = "BookstoreAppConnectionString";
        public UserRepository(IConfiguration configuration)
        {
            this.config = configuration;
        }
        public string Register(RegisterModel registerModel)
        {
            try
            {
                if (registerModel != null)
                {
                    string ConnectionStrings = config.GetConnectionString(connectionString);
                    using (SqlConnection con = new SqlConnection(ConnectionStrings))
                    {
                        SqlCommand cmd = new SqlCommand("spForAddingUsers", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FullName", registerModel.FullName);
                        cmd.Parameters.AddWithValue("@EmailId", registerModel.EmailId);
                        cmd.Parameters.AddWithValue("@Password", registerModel.Password);
                        cmd.Parameters.AddWithValue("@MobileNum", registerModel.MobileNum);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return "Registration is successful";
                    }
                }
                else
                {
                    return "Registration is unsuccessful";
                }
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }
        public string Login(LoginModel loginModel)
        {
            try
            {
                if (loginModel != null)
                {
                    string ConnectionStrings = config.GetConnectionString(connectionString);
                    SqlDataReader dr;
                    using (SqlConnection con = new SqlConnection(ConnectionStrings))
                    {
                        SqlCommand cmd = new SqlCommand("spForLogin", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailId", loginModel.EmailId);
                        cmd.Parameters.AddWithValue("@Password", loginModel.Password);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return "Login is successful";
                        }
                    }
                }
                        return "Login is unsuccessful";
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }
    }
}
