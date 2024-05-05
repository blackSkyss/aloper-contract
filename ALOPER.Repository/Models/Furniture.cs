using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Models
{
    public class Furniture
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFurniture {  get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ContractId")]
        public virtual Contract Contract { get; set; }
    }
}
