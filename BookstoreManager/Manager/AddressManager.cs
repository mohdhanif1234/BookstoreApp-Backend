using BookstoreManager.Interface;
using BookstoreModels;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManager.Manager
{
    public class AddressManager : IAddressManager
    {
        private readonly IAddressRepository addressRepository;
        public AddressManager(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public string AddUserAddress(AddressModel addressModel)
        {
            try
            {
                return this.addressRepository.AddUserAddress(addressModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
