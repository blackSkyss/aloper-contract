using ALOPER.Repository.Models;
using ALOPER.Service.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<Repository.Models.Contract, InsertContractRequest>().ReverseMap();
            CreateMap<Repository.Models.Contract, UpdateContractRequest>().ReverseMap();
            CreateMap<Repository.Models.Contract, ContractResponse>().ReverseMap();
        }
    }
}
