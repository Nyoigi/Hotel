using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class PersonalArea
    {
        public int IdPersonal { get; set; }
        public int Login { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
        public int GuestDetailsId { get; set; }

        public virtual GuestDetail GuestDetails { get; set; }
    }
}
