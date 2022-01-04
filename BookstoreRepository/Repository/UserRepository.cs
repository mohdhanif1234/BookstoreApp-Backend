﻿using BookstoreModels;
using BookstoreRepository.Interface;
using Experimental.System.Messaging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
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
        public string EncryptPassword(string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
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
                        cmd.Parameters.AddWithValue("@Password", EncryptPassword(registerModel.Password));
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
        public string ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                if (resetPasswordModel.EmailId != null)
                {
                    string ConnectionStrings = config.GetConnectionString(connectionString);
                    using (SqlConnection con = new SqlConnection(ConnectionStrings))
                    {
                        SqlCommand cmd = new SqlCommand("spForResetPassword", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailId", resetPasswordModel.EmailId);
                        cmd.Parameters.AddWithValue("@NewPassword", EncryptPassword(resetPasswordModel.NewPassword));
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return "Password reset is successful";
                        }
                    }
                }
                    return "The Email Id does not exist. Password reset is unsuccessful";
            }
            catch (ArgumentException e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }
        public string ForgotPassword(string EmailId)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForForgotPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", EmailId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        SMTP(EmailId);
                        return "Email is sent successfully";
                    }
                    else
                    {
                        return "Email Id does not exist";
                    }

                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void SMTP(string EmailId)
        {
            MailMessage mailId = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mailId.From = new MailAddress(this.config["Credentials:testEmailId"]);
            mailId.To.Add(EmailId);
            mailId.Subject = "Test Mail";
            this.SendMSMQ();
            mailId.Body = this.ReceiveMSMQ();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(this.config["Credentials:testEmailId"], this.config["Credentials:testEmailPassword"]);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mailId);
        }
        public void SendMSMQ()
        {
            MessageQueue msgQueue;
            if (MessageQueue.Exists(@".\Private$\book"))
            {
                msgQueue = new MessageQueue(@".\Private$\book");
            }
            else
            {
                msgQueue = MessageQueue.Create(@".\Private$\book");
            }
            Message message = new Message();
            var formatter = new BinaryMessageFormatter();
            message.Formatter = formatter;
            message.Body = "This mail is to reset password";
            msgQueue.Label = "MailBody";
            msgQueue.Send(message);
        }

        public string ReceiveMSMQ()
        {
            var receivequeue = new MessageQueue(@".\Private$\book");
            var receivemsg = receivequeue.Receive();
            receivemsg.Formatter = new BinaryMessageFormatter();
            return receivemsg.Body.ToString();
        }
    }
}
