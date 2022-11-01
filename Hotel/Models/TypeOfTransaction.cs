using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class TypeOfTransaction
    {
        public TypeOfTransaction()
        {
            FinancialDepartaments = new HashSet<FinancialDepartament>();
        }

        public int IdTypeOfTransaction { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
        public bool Deleting { get; set; }

        public virtual ICollection<FinancialDepartament> FinancialDepartaments { get; set; }
    }
}
