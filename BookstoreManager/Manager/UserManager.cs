using BookstoreManager.Interface;
using BookstoreModels;
using BookstoreRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public string Register(RegisterModel registerModel)
        {
            try
            {
                return this.repository.Register(registerModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
