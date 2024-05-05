using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALOPER.Repository.Models
{
    public class Service
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdService { get; set; }
        public int PriceService { get; set; }
        public string Dvt {  get; set; }
        public int OldNumber {  get; set; }
        public string Name { get; set; }

        [ForeignKey("ContractId")]
        public virtual Contract Contract { get; set; }
    }
}
