using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            GuestDetails = new HashSet<GuestDetail>();
        }

        public int IdReservation { get; set; }
        public int CashboxId { get; set; }
        public int RoomId { get; set; }
        public int TimeId { get; set; }
        public bool Deleting { get; set; }

        public virtual Cashbox Cashbox { get; set; }
        public virtual Room Room { get; set; }
        public virtual BookingTime Time { get; set; }
        public virtual ICollection<GuestDetail> GuestDetails { get; set; }
    }
}
