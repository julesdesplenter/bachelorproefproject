﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicAPI.Models
{
    public class filterDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double Level { get; set; }
    }
}