using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IUserManager
    {
        string Register(RegisterModel registerModel);
        string Login(LoginModel loginModel);
    }
}