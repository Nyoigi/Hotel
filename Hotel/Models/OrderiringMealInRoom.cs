using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class OrderiringMealInRoom
    {
        public int IdOrderiringMealInRoom { get; set; }
        public TimeSpan TimeOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int MenuId { get; set; }
        public int RoomId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Room Room { get; set; }
    }
}
