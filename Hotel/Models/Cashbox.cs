using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class Cashbox
    {
        public Cashbox()
        {
            AdditionalServices = new HashSet<AdditionalService>();
            Reservations = new HashSet<Reservation>();
            Restaurants = new HashSet<Restaurant>();
        }

        public int IdCashbox { get; set; }
        public int FinancialDepartamentId { get; set; }

        public virtual FinancialDepartament FinancialDepartament { get; set; }
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
