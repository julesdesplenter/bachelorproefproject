using System;
using System.Collections.Generic;
using System.Text;

namespace SMSong.Interfaces
{
    public class Position
    {
        public Guid PositionID { get; set; }
        public double Length { get; set; }
        public int Place { get; set; }
        public List<Tone> Tones { get; set; }
    }
}
