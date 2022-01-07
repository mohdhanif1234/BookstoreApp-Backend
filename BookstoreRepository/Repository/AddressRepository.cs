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
    public class AddressRepository : IAddressRepository
    {
        private readonly IConfiguration config;
        public string connectionString { get; set; } = "BookstoreAppConnectionString";
        public AddressRepository(IConfiguration configuration)
        {
            this.config = configuration;
        }
        public string AddUserAddress(AddressModel addressModel)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("SpForAddingUserAddressDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", addressModel.UserId);
                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        return "User address details added successfully";
                    }
                    else
                    {
                        return "UserId does not exits";
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string UpdateUserAddress(AddressModel addressModel)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForUpdatingUserAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", addressModel.AddressId);
                    cmd.Parameters.AddWithValue("@Address", addressModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressModel.City);
                    cmd.Parameters.AddWithValue("@State", addressModel.State);
                    cmd.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        return "User address updated successfully";
                    }
                    else
                    {
                        return "Address does not exist";
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<AddressModel> GetAddressByUserId(int userId)
        {
            try
            {
                string ConnectionStrings = config.GetConnectionString(connectionString);
                using (SqlConnection con = new SqlConnection(ConnectionStrings))
                {
                    SqlCommand cmd = new SqlCommand("spForGettingAddressDetailsByUserId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        List<AddressModel> addressList = new List<AddressModel>();
                        while (dr.Read())
                        {
                            AddressModel addressModel = new AddressModel();
                            addressModel.AddressId = Convert.ToInt32(dr["AddressId"]);
                            addressModel.Address = dr["Address"].ToString();
                            addressModel.City = dr["City"].ToString();
                            addressModel.State = dr["State"].ToString();
                            addressModel.TypeId = Convert.ToInt32(dr["TypeId"]);
                            addressModel.UserId = Convert.ToInt32(dr["UserId"]);
                            addressList.Add(addressModel);
                        }
                        return addressList;
                    }
                    else
                    {
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
