using MinimalAPI.Models.DTOs;

namespace MinimalAPI.Services
{
    public interface IProductServices
    {
        Task<Response> Add(AddRequestDTO request);
        Task<Response> Update(UpdateRequestDTO request);
        Task<List<ResponseDTO>> GetAll();
        Task<ResponseDTO> GetById(int Id);
        Task<Response> Delete(int Id);
    }
}
 