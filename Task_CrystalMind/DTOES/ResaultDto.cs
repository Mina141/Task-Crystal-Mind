using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_CrystalMind.DTOES
{
    public class ResaultDto
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}
