using BookstoreModels;

namespace BookstoreRepository.Interface
{
    public interface IUserRepository
    {
        string connectionString { get; set; }
        string Register(RegisterModel registerModel);
        string Login(LoginModel loginModel);
    }
}