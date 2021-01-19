using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicAPI.Models
{
    public class tokenDTO
    {
        public object Token { get; set; }
        public Dictionary<string,Guid> User { get; set; }
    }
}
