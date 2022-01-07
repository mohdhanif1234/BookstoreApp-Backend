using BookstoreModels;
using System.Collections.Generic;

namespace BookstoreManager.Interface
{
    public interface IAddressManager
    {
        string AddUserAddress(AddressModel addressModel);
        string UpdateUserAddress(AddressModel addressModel);
        List<AddressModel> GetAddressByUserId(int userId);
        List<AddressModel> GetAllAddressDetails();
    }
}