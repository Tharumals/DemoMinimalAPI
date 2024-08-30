using MinimalAPI.Models.DTOs;

namespace MinimalAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Response> Add(AddRequestDTO request);
        Task<Response> Update(UpdateRequestDTO request);
        Task<List<ResponseDTO>> GetAll();
        Task<ResponseDTO> GetById(int Id);
        Task<Response> Delete(int Id);
    }
}
