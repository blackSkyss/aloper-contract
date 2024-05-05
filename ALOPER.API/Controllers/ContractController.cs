﻿using ALOPER.Service.DTOs;
using ALOPER.Service.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MBKC.API.Constants;
using MBKC.Service.Exceptions;
using MBKC.Service.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ALOPER.API.Controllers
{
    [ApiController]
    public class ContractController : ControllerBase
    {
        private IContractService _contractService;
        private IValidator<InsertContractRequest> _insertContractValidator;
        private IValidator<UpdateContractRequest> _updateContractValidator;
        public ContractController(IContractService contractService, 
            IValidator<InsertContractRequest> insertContractValidato,
            IValidator<UpdateContractRequest> updateContractValidator)
        {
            _contractService = contractService;
            _insertContractValidator = insertContractValidato;
            _updateContractValidator = updateContractValidator;
        }

        #region Insert Contract
        /// <summary>
        /// Lên hợp đồng
        /// </summary>
        /// <returns>
        /// return success status.
        /// </returns>
        /// <remarks>
        ///     Sample request:
        ///
        ///         POST
        ///         {
        ///             "idRoom": 10,
        ///             "id": "akdmchgifk",
        ///             "rentalTerm": 10,
        ///             "depositDate": "2024-05-04T07:08:37.584Z",
        ///             "depositAmount": 10000,
        ///             "rentalPrice": 100,
        ///             "rentalStartDate": "2024-05-04T07:08:37.584Z",
        ///             "numberOfPeople": 10,
        ///             "numberOfVehicle": 10,
        ///             "fullName": "Le Hong Thanh",
        ///             "phoneNumber": "0987654321",
        ///             "birthOfDay": "2024-05-04T07:08:37.584Z",
        ///             "identification": "hghghgh",
        ///             "dateRange": "2024-05-04T07:08:37.584Z",
        ///             "issuedBy": "Le Hong Thanh",
        ///             "permanentAddress": "64 Hang Tre",
        ///             "signature": "Thanh Le",
        ///             "contractEndDate": "2024-05-04T07:08:37.584Z",
        ///             "note": "Note note note",
        ///             "services": [
        ///               {
        ///                 "idService": 1,
        ///                 "priceService": 100,
        ///                 "dvt": "Note note note",
        ///                 "oldNumber": 10,
        ///                 "name": "Car wash"
        ///               },
        ///               {
        ///                 "idService": 2,
        ///                 "priceService": 1000,
        ///                 "dvt": "Note note note",
        ///                 "oldNumber": 15,
        ///                 "name": "Bike wash"
        ///               }
        ///             ],
        ///             "furnitures": [
        ///               {
        ///                 "idFurniture": 1,
        ///                 "price":95,
        ///                 "note": "Note note note",
        ///                 "name": "Table bench",
        ///                 "status": "New",
        ///                 "isActive": true
        ///               },
        ///               {
        ///                 "idFurniture": 2,
        ///                 "price": 100,
        ///                 "note": "Note note note",
        ///                 "name": "Table Wood",
        ///                 "status": "Medium",
        ///                 "isActive": true
        ///               }
        ///             ]
        ///         }
        /// </remarks>
        [HttpPost(APIEndPointConstant.ContractEndpoint.InsertContractEndpoint)]
        public async Task<IActionResult> InsertContract([FromBody] InsertContractRequest contract)
        {
            ValidationResult validationResult = await this._insertContractValidator.ValidateAsync(contract);
            if (validationResult.IsValid == false)
            {
                string errors = ErrorUtil.GetErrorsString(validationResult);
                throw new BadRequestException(errors);
            }
            await _contractService.InsertContract(contract);
            return Ok("Insert contract successfully.");
        }
        #endregion

        #region Get contract by id
        /// <summary>
        /// Lấy hợp đồng by ID.
        /// </summary>
        /// <param name="id">id of contract.</param>
        /// <returns>
        /// An object contains the contract information.
        /// </returns>
        /// <remarks>
        ///     Sample request:
        ///
        ///         GET 
        ///         id = 1
        /// </remarks>
        [HttpGet(APIEndPointConstant.ContractEndpoint.GetContractEndpoint)]
        public async Task<IActionResult> GetContractById([FromRoute] string id)
        {
            var contractReponse = await _contractService.GetContractById(id);
            return Ok(contractReponse);
        }
        #endregion

        #region Cancel contract
        /// <summary>
        /// Hủy hợp đồng theo ID hợp đồng.
        /// </summary>
        /// <param name="id"> id of contract.</param>
        /// <returns>
        /// Cancel contract.
        /// </returns>
        /// <remarks>
        ///     Sample request:
        ///
        ///         GET 
        ///         id = 1
        /// </remarks>
        [HttpPut(APIEndPointConstant.ContractEndpoint.CancelContractEndpoint)]
        public async Task<IActionResult> CancelContract([FromRoute] string id)
        {
            await _contractService.CancelContract(id);
            return Ok("cancel contract successfully.");
        }
        #endregion

        #region Update contract
        /// <summary>
        /// Cập nhật thông tin hợp đồng.
        /// </summary>
        /// <returns>
        /// Success status.
        /// </returns>
        /// <remarks>
        ///     Sample request:
        ///
        ///         PUT
        ///         ID = akdmchgifk
        ///         {
        ///             "idRoom": 100,
        ///             "rentalTerm": 15,
        ///             "depositDate": "2024-05-04T07:08:37.584Z",
        ///             "depositAmount": 10000,
        ///             "rentalPrice": 100,
        ///             "rentalStartDate": "2024-05-04T07:08:37.584Z",
        ///             "numberOfPeople": 10,
        ///             "numberOfVehicle": 10,
        ///             "fullName": "Le Hong Thanh",
        ///             "phoneNumber": "0987654321",
        ///             "birthOfDay": "2024-05-04T07:08:37.584Z",
        ///             "identification": "hghghgh",
        ///             "dateRange": "2024-05-04T07:08:37.584Z",
        ///             "issuedBy": "Le Hong Thanh",
        ///             "permanentAddress": "64 Hang Tre",
        ///             "signature": "Thanh Le",
        ///             "contractEndDate": "2024-05-04T07:08:37.584Z",
        ///             "note": "Note note note",
        ///             "services": [
        ///               {
        ///                 "idService": 3,
        ///                 "priceService": 50,
        ///                 "dvt": "Note note note",
        ///                 "oldNumber": 10,
        ///                 "name": "Car wash"
        ///               },
        ///               {
        ///                 "idService": 4,
        ///                 "priceService": 2000,
        ///                 "dvt": "Note note note",
        ///                 "oldNumber": 15,
        ///                 "name": "Bike wash"
        ///               }
        ///             ],
        ///             "furnitures": [
        ///               {
        ///                 "idFurniture": 3,
        ///                 "price": 100,
        ///                 "note": "Note note note",
        ///                 "name": "Table bench",
        ///                 "status": "New",
        ///                 "isActive": true
        ///               },
        ///               {
        ///                 "idFurniture": 4,
        ///                 "price": 150,
        ///                 "note": "Note note note",
        ///                 "name": "Table Wood",
        ///                 "status": "Medium",
        ///                 "isActive": true
        ///               }
        ///             ]
        ///         }
        /// </remarks>
        [HttpPut(APIEndPointConstant.ContractEndpoint.UpdateContractEndpoint)]
        public async Task<IActionResult> UpdateContract([FromBody] UpdateContractRequest contract, [FromRoute] string id)
        {
            ValidationResult validationResult = await this._updateContractValidator.ValidateAsync(contract);
            if (validationResult.IsValid == false)
            {
                string errors = ErrorUtil.GetErrorsString(validationResult);
                throw new BadRequestException(errors);
            }
            await _contractService.UpdateContract(contract, id);
            return Ok("Update contract successfully.");
        }
        #endregion

    }
}
