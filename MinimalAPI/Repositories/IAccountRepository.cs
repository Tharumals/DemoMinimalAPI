using MinimalAPI.Models.DTOs;

namespace MinimalAPI.Repositories
{
    public interface IAccountRepository
    {
        Task<Response> Register(RegisterDTO register);
        Task<LoginResponse> Login(LoginDTO loginDTO);
    }
}
