using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_CrystalMind.Models
{
    public class Customer : BaseModel
    {
        public string Cust_FName { get; set; }
        public string Cust_LName { get; set; }
        public char Cust_Gender { get; set; }
        public string Cust_DOB { get; set; }
        public string Cust_Email { get; set; }

        public virtual IList<Address> Addresses { get; set; }

    }
}
