using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullCsharp.DTOs
{
    public class PaqueteDTO
    {
        public PaqueteDTO() { }
        public int status { get; set; }
        public string msn { get; set; }
        public Array data { get; set; }
    }
}
