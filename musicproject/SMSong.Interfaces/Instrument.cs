using System;
using System.Collections.Generic;
using System.Text;

namespace SMSong.Interfaces
{
    public class Instrument
    {
        public Guid InstrumentId { get; set; }
        public string Name { get; set; }
        public List<Position> Positions { get; set; }
    }
}
