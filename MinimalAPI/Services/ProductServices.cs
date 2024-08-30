using MinimalAPI.Models.DTOs;
using MinimalAPI.Repositories;

namespace MinimalAPI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _product;
        public ProductServices(IProductRepository product)
        {
            _product = product;
        }
        public async Task<Response> Add(AddRequestDTO request) =>
            await _product.Add(request);
        

        public async Task<Response> Delete(int Id)=>
            await _product.Delete(Id);

        public async Task<List<ResponseDTO>> GetAll() =>
            await _product.GetAll();

        public async Task<ResponseDTO> GetById(int Id) =>
            await _product.GetById(Id);

        public async Task<Response> Update(UpdateRequestDTO request)=>
            await _product.Update(request);
    }
}
