using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.DTOs
{
    public class UpdateContractRequest
    {
        public int IdRoom { get; set; }
        public int rentalTerm { get; set; }
        public DateTime DepositDate { get; set; }
        public int DepositAmount { get; set; }
        public int RentalPrice { get; set; }
        public DateTime RentalStartDate { get; set; }
        public int NumberOfPeople { get; set; }
        public int NumberOfVehicle { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthOfDay { get; set; }
        public string Identification { get; set; }
        public DateTime DateRange { get; set; }
        public string IssuedBy { get; set; }
        public string PermanentAddress { get; set; }
        public string Signature { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string Note { get; set; }
        public virtual IEnumerable<ServiceRequest> Services { get; set; }
        public virtual IEnumerable<FurnitureRequest> Furnitures { get; set; }
    }
}
