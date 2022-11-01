using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class PhotoRoom
    {
        public PhotoRoom()
        {
            Rooms = new HashSet<Room>();
        }

        public int IdPhotoRoom { get; set; }
        public string PhotoOfTheRoom { get; set; }
        public bool Deleting { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
