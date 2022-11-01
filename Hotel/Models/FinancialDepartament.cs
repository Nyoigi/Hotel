using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class FinancialDepartament
    {
        public FinancialDepartament()
        {
            Cashboxes = new HashSet<Cashbox>();
        }

        public int IdFinancialDepartament { get; set; }
        public int Summ { get; set; }
        public bool Deleting { get; set; }
        public int TypeOfTransactionId { get; set; }

        public virtual TypeOfTransaction TypeOfTransaction { get; set; }
        public virtual ICollection<Cashbox> Cashboxes { get; set; }
    }
}
