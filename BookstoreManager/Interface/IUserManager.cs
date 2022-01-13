using BookstoreModels;

namespace BookstoreManager.Interface
{
    public interface IUserManager
    {
        string Register(RegisterModel registerModel);
        string Login(LoginModel loginModel);
        string ResetPassword(ResetPasswordModel resetPasswordModel);
        string ForgotPassword(string EmailId);
        string JWTTokenGeneration(string email);
    }
}