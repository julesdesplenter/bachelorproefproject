using System;
using System.Collections.Generic;
using System.Text;

namespace UPSong.Interfaces
{
    public class Filter
    {
        public Guid FilterId { get; set; }
        public string Name { get; set; }
        public double Level { get; set; }
    }
}
