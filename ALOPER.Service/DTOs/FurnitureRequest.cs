using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Service.DTOs
{
    public class FurnitureRequest
    {
        public int IdFurniture { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}
