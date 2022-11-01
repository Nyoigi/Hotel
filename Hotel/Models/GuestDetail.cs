using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class GuestDetail
    {
        public GuestDetail()
        {
            PersonalAreas = new HashSet<PersonalArea>();
        }

        public int IdGuestDetails { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public int RoomId { get; set; }
        public int RoomClassId { get; set; }
        public int TimeId { get; set; }
        public int ReservationId { get; set; }
        public int CheckInId { get; set; }
        public bool Deleting { get; set; }

        public virtual CheckIn CheckIn { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<PersonalArea> PersonalAreas { get; set; }
    }
}
