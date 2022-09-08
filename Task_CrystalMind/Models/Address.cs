using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task_CrystalMind.Models
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public string Zone { get; set; }
        public string City { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
