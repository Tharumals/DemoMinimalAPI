using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Models.DTOs;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response> Add(AddRequestDTO request)
        {
            _context.Products.Add(_mapper.Map<Product>(request));
            await _context.SaveChangesAsync();
            return new Response(true, "Saved");
        }

        public async Task<Response> Delete(int Id)
        {
            _context.Products.Remove(await _context.Products.FindAsync(Id));
            await _context.SaveChangesAsync();
            return new Response(true, "Deleted");
        }

        public async Task<List<ResponseDTO>> GetAll() =>
            _mapper.Map<List<ResponseDTO>>(await _context.Products.ToListAsync());

        public async Task<ResponseDTO> GetById(int Id) =>
            _mapper.Map<ResponseDTO>(await _context.Products.FindAsync(Id));

        public async Task<Response> Update(UpdateRequestDTO request)
        {
            _context.Products.Update(_mapper.Map<Product>(request));
            await _context.SaveChangesAsync();
            return new Response(true, "Updates");

        }
    }
}
