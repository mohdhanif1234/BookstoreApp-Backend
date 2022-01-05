﻿using BookstoreModels;
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
                    return "Book details added successfully";
                }
                else
                {
                    return "Books details addition is unsuccessful";
                }
            }
        }
    }
}
