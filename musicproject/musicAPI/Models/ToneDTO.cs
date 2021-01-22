using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicAPI.Models
{
    public class ToneDTO
    {
        public Guid UserId { get; set; }
       
        public string Pitch { get; set; }
    }
}
