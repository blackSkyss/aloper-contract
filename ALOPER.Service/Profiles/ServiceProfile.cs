using ALOPER.Repository.Models;
using ALOPER.Service.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Repository.Models.Service, ServiceRequest>().ReverseMap();
        }
    }
}
