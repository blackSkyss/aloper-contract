using ALOPER.Repository.Models;
using ALOPER.Service.DTOs;
using AutoMapper;

namespace ALOPER.Service.Profiles
{
    public class FurnitureProfile : Profile
    {
        public FurnitureProfile()
        {
            CreateMap<Furniture, FurnitureRequest>().ReverseMap();
        }
    }
}
