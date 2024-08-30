using MinimalAPI.Models.DTOs;
using MinimalAPI.Repositories;

namespace MinimalAPI.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _repository;
        public AccountServices(IAccountRepository repository)
        {
            _repository = repository;
        }
        public Task<LoginResponse> Login(LoginDTO loginDTO)=>
            _repository.Login(loginDTO);

        

        public Task<Response> Register(RegisterDTO registerDTO)=>
            _repository.Register(registerDTO);
    }
}
