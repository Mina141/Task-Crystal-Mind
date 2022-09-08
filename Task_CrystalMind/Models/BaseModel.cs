using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_CrystalMind.Models
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }
    }
}
