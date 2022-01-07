using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IAddressManager
    {
        string AddUserAddress(AddressModel addressModel);
    }
}