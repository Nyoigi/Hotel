using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class BookingTime
    {
        public BookingTime()
        {
            Reservations = new HashSet<Reservation>();
            Rooms = new HashSet<Room>();
        }

        public int IdTime { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool Deleting { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
