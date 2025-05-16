using FactoryProject.Models.UserDtos;

namespace FactoryProject.Contracts
{
    public interface IAuthService
    {
        Task<String>? LoginAsync(LoginModel loginModel);

        Task SetAuthenticateAsync(String token);
        Task LogoutAsync();
        
    }
}