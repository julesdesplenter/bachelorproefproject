using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicAPI.Models
{
    public class positionDTO
    {
        public Guid UserId { get; set; }
        public double Length { get; set; }
        public int Place { get; set; }

    }
}
