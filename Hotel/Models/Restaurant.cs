using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class Restaurant
    {
        public int IdRestaurant { get; set; }
        public int NumberOrder { get; set; }
        public int CashboxId { get; set; }
        public int MenuId { get; set; }

        public virtual Cashbox Cashbox { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
