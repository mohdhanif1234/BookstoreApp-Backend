using BookstoreModels;

namespace BookstoreRepository.Interface
{
    public interface IAddressRepository
    {
        string connectionString { get; set; }
        string AddUserAddress(AddressModel addressModel);
    }
}