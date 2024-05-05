using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.DTOs
{
    public class ServiceRequest
    {
        public int IdService { get; set; }
        public int PriceService { get; set; }
        public string Dvt { get; set; }
        public int OldNumber { get; set; }
        public string Name { get; set; }
    }
}
