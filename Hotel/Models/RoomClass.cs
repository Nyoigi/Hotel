using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class RoomClass
    {
        public RoomClass()
        {
            Rooms = new HashSet<Room>();
        }

        public int IdRoomClass { get; set; }
        public string RoomType { get; set; }
        public bool Deleting { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
