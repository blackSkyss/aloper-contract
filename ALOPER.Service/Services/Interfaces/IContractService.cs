using ALOPER.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.Services.Interfaces
{
    public interface IContractService
    {
        Task InsertContract(InsertContractRequest contract);
        Task<ContractResponse> GetContractById(string id);
        Task UpdateContract(UpdateContractRequest contract, string id);
        Task CancelContract(string id);
    }
}
