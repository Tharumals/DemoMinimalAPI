using MinimalAPI.Models.DTOs;

namespace MinimalAPI.Services
{
    public interface IAccountServices
    {
        Task<Response> Register(RegisterDTO register);
        Task<LoginResponse> Login(LoginDTO loginDTO);
    }
}
 