using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class CheckIn
    {
        public CheckIn()
        {
            GuestDetails = new HashSet<GuestDetail>();
        }

        public int IdCheckIn { get; set; }
        public int AdditionalServicesId { get; set; }

        public virtual AdditionalService AdditionalServices { get; set; }
        public virtual ICollection<GuestDetail> GuestDetails { get; set; }
    }
}
