using ALOPER.Repository.Infrastructures;
using ALOPER.Service.DTOs;
using ALOPER.Service.Services.Interfaces;
using AutoMapper;
using MBKC.Service.Exceptions;
using MBKC.Service.Utils;
using Spire.Doc;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Document = Spire.Doc.Document;


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

        public Task<byte[]> ExportPDFFile(string path, DataContractRequest contract)
        {
            byte[]? docxBytes = null;
            byte[]? pdfBytes = null;

            #region input data into docx
            using (WordDocument document = new WordDocument())
            {
                using (var docStream = File.OpenRead(path))
                {
                    document.Open(docStream, FormatType.Docx);

                    document.Replace("fullnamesalep", contract.FullNameSale, true, true);
                    document.Replace("passportsalep", contract.PassportNumberSale, true, true);
                    document.Replace("phonesalep", contract.PhoneNumberSale, true, true);
                    document.Replace("postitionsalep", contract.PositionSale, true, true);
                    document.Replace("fullnamecusp", contract.FullNameCus, true, true);
                    document.Replace("passportcusp", contract.PassportNumberCus, true, true);
                    document.Replace("phonecusp", contract.FullNameCus, true, true);
                    document.Replace("placep", contract.PlaceCus, true, true);
                    document.Replace("addressp", contract.Address, true, true);
                    document.Replace("roomcodep", contract.RoomCode, true, true);
                    document.Replace("leasetermp", contract.LeaseTerm, true, true);
                    document.Replace("rentalfeep", contract.RentalFee.ToString(), true, true);
                    document.Replace("checkinp", contract.CheckinDate.ToString("dd/MM/yyyy"), true, true);
                    document.Replace("bookingamountp", contract.BookingAmount.ToString(), true, true);
                    document.Replace("additionamountp", contract.AdditionalAmount.ToString(), true, true);
                    document.Replace("deadlinep", contract.PaymentDeadline.ToString("dd/MM/yyyy"), true, true);
                    document.Replace("rewardp", string.IsNullOrEmpty(contract.Reward) ? "......" : contract.Reward, true, true);
                    document.Replace("electricityfeep", contract.ElectricityFee.ToString(), true, true);
                    document.Replace("waterfeep", contract.WaterFee.ToString(), true, true);
                    document.Replace("parkingfeep", contract.ParkingFee.ToString(), true, true);
                    document.Replace("manafeep", contract.ManagementFee.ToString(), true, true);
                    document.Replace("otherfeep", contract.OthersFee?.ToString() ?? "......", true, true);
                    document.Replace("ddp", contract.SignDate.Day.ToString(), true, true);
                    document.Replace("mmp", contract.SignDate.Month.ToString(), true, true);
                    document.Replace("yyyyp",contract.SignDate.Year.ToString(), true, true);
                    document.Replace("signcustomer", contract.SignCustomer, true, true);
                    document.Replace("signsale", contract.SignSale, true, true);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        document.Save(memoryStream, FormatType.Docx);
                        docxBytes = memoryStream.ToArray();
                    }
                }
            }
            #endregion

            #region convert docx to pdf
            using (var doc = new Document())
            {
                doc.LoadFromStream(new MemoryStream(docxBytes), FileFormat.Docx);
                using (var pdfStream = new MemoryStream())
                {
                    doc.SaveToStream(pdfStream, FileFormat.PDF);
                    pdfBytes = pdfStream.ToArray();
                }
            }
            #endregion

            return Task.FromResult(pdfBytes);
        }
    }
}
