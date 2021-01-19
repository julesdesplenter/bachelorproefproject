using System;
using System.Collections.Generic;
using System.Text;

namespace SMSong.Interfaces
{
    public class SMSongClass
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public List<Instrument> Instruments { get; set; }
    }
}
