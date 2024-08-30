using AutoMapper;
using MinimalAPI.Models.DTOs;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AddRequestDTO, Product>();
            CreateMap<UpdateRequestDTO, Product>();
            CreateMap<Product, ResponseDTO>();
            CreateMap<RegisterDTO, User>();

        }
    }
}
