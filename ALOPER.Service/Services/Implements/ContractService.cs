using ALOPER.Repository.Infrastructures;
using ALOPER.Repository.Models;
using ALOPER.Service.DTOs;
using ALOPER.Service.Services.Interfaces;
using AutoMapper;
using MBKC.Service.Exceptions;
using MBKC.Service.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.Services.Implements
{
    public class ContractService : IContractService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
            _mapper = mapper;
        }
        public async Task<ContractResponse> GetContractById(string id)
        {
            try
            {
                var existedContract = await _unitOfWork.ContractRepository.GetContractById(id);
                if (existedContract is null)
                {
                    throw new NotFoundException("contract does not exist.");
                }

                return _mapper.Map<ContractResponse>(existedContract);
            }
            catch (NotFoundException ex)
            {
                string error = ErrorUtil.GetErrorString("get contract by id", ex.Message);
                throw new NotFoundException(error);
            }
        }

        public async Task InsertContract(InsertContractRequest contract)
        {
            try
            {
                var existedContract = await _unitOfWork.ContractRepository.GetContractById(contract.Id);
                if (existedContract is not null) throw new BadRequestException("id already existed.");

                var duplicateSerivce = contract.Services.GroupBy(s => s.IdService).Any(g => g.Count() > 1);
                if (duplicateSerivce) throw new BadRequestException("duplicate service id.");

                var duplicateFurniture = contract.Furnitures.GroupBy(s => s.IdFurniture).Any(g => g.Count() > 1);
                if (duplicateFurniture) throw new BadRequestException("duplicate furniture id.");

                foreach (var service in contract.Services)
                {
                    var existedService = await _unitOfWork.ServiceRepository.GetByID(service.IdService);
                    if (existedService is not null) throw new BadRequestException("service id already existed.");
                }

                foreach (var furniture in contract.Furnitures)
                {
                    var existedFurniture = await _unitOfWork.FurnitureRepository.GetByID(furniture.IdFurniture);
                    if (existedFurniture is not null) throw new BadRequestException("furniture id already existed.");
                }

                var contractInsert = _mapper.Map<Repository.Models.Contract>(contract);
                await _unitOfWork.ContractRepository.Insert(contractInsert);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (BadRequestException ex)
            {
                string error = ErrorUtil.GetErrorString("insert contract", ex.Message);
                throw new BadRequestException(error);
            }
        }
        public async Task UpdateContract(UpdateContractRequest contract, string id)
        {
            try
            {
                var existedContract = await _unitOfWork.ContractRepository.GetContractById(id);
                if (existedContract is null) throw new NotFoundException("contract does not exist.");

                var duplicateSerivce = contract.Services.GroupBy(s => s.IdService).Any(g => g.Count() > 1);
                if (duplicateSerivce) throw new BadRequestException("duplicate service id.");

                var duplicateFurniture = contract.Furnitures.GroupBy(s => s.IdFurniture).Any(g => g.Count() > 1);
                if (duplicateFurniture) throw new BadRequestException("duplicate furniture id.");


                foreach (var service in contract.Services)
                {
                    var existedService = await _unitOfWork.ServiceRepository.GetServiceById(service.IdService);
                    if (existedService is not null && !existedService.Contract.Id.ToLower().Equals(id.ToLower())) throw new BadRequestException("service id already existed.");
                }

                foreach (var furniture in contract.Furnitures)
                {
                    var existedFurniture = await _unitOfWork.FurnitureRepository.GetFurnitureById(furniture.IdFurniture);
                    if (existedFurniture is not null && !existedFurniture.Contract.Id.ToLower().Equals(id.ToLower())) throw new BadRequestException("furniture id already existed.");
                }

                _mapper.Map(contract, existedContract);

                await _unitOfWork.FurnitureRepository.RemoveFurnites(id);
                await _unitOfWork.ServiceRepository.RemoveServices(id);
                _unitOfWork.ContractRepository.Update(existedContract);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (BadRequestException ex)
            {
                string error = ErrorUtil.GetErrorString("update contract", ex.Message);
                throw new BadRequestException(error);
            }
            catch (NotFoundException ex)
            {
                string error = ErrorUtil.GetErrorString("update contract", ex.Message);
                throw new NotFoundException(error);
            }

        }

        public async Task CancelContract(string id)
        {
            try
            {
                var existedContract = await _unitOfWork.ContractRepository.GetContractById(id);
                if (existedContract is null) throw new NotFoundException("contract does not exist.");

                _unitOfWork.ContractRepository.Delete(existedContract);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (NotFoundException ex)
            {
                string error = ErrorUtil.GetErrorString("cancel contract", ex.Message);
                throw new NotFoundException(error);
            }
        }
    }
}
