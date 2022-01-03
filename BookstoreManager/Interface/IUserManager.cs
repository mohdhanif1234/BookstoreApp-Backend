using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IUserManager
    {
        string Login(LoginModel loginModel);
    }
}