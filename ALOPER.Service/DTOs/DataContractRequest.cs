using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.DTOs
{
    public class DataContractRequest
    {
        public string FullNameSale { get; set; }
        public string PassportNumberSale { get; set; }
        public string PhoneNumberSale { get; set; }
        public string PositionSale { get; set; }
        public string FullNameCus {  get; set; }
        public string PassportNumberCus { get; set; }
        public string PhoneNumberCus { get; set; }
        public string PlaceCus { get; set; }
        public string Address {  get; set; }
        public string RoomCode { get; set; }
        public string LeaseTerm { get; set; }
        public int RentalFee { get; set; }
        public DateTime CheckinDate { get; set; }
        public int BookingAmount { get; set; }
        public int AdditionalAmount { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public string? Reward { get; set; }
        public int ElectricityFee { get; set; }
        public int WaterFee {  get; set; }
        public int ParkingFee { get; set; }
        public int ManagementFee { get; set; }
        public int? OthersFee { get; set; }
        public DateTime SignDate { get; set; }
        public string SignCustomer { get; set; }
        public string SignSale { get; set; }
    }
}
