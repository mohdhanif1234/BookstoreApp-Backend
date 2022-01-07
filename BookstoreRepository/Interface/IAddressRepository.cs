using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreRepository.Interface
{
    public interface IAddressRepository
    {
        string connectionString { get; set; }
        string AddUserAddress(AddressModel addressModel);
        string UpdateUserAddress(AddressModel addressModel);
        List<AddressModel> GetAddressByUserId(int userId);
    }
}