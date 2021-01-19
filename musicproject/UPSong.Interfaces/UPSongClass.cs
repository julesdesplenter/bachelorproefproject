using System;
using System.Collections.Generic;
using System.Text;

namespace UPSong.Interfaces
{
    public class UPSongClass
    {
        public Guid SongId { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
        public List<Filter> filters { get; set; }
    }
}
