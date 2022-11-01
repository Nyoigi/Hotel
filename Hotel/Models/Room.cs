using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class Room
    {
        public Room()
        {
            GuestDetails = new HashSet<GuestDetail>();
            OrderiringMealInRooms = new HashSet<OrderiringMealInRoom>();
            Reservations = new HashSet<Reservation>();
        }

        public int IdRoom { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfSeats { get; set; }
        public string NameRoom { get; set; }
        public int Price { get; set; }
        public int PhotoRoomId { get; set; }
        public int RoomClassId { get; set; }
        public int TimeId { get; set; }
        public bool Deleting { get; set; }

        public virtual PhotoRoom PhotoRoom { get; set; }
        public virtual RoomClass RoomClass { get; set; }
        public virtual BookingTime Time { get; set; }
        public virtual ICollection<GuestDetail> GuestDetails { get; set; }
        public virtual ICollection<OrderiringMealInRoom> OrderiringMealInRooms { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
