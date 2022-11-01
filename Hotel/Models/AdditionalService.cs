using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class AdditionalService
    {
        public AdditionalService()
        {
            CheckIns = new HashSet<CheckIn>();
        }

        public int IdAdditionalServices { get; set; }
        public string ServiceName { get; set; }
        public int Price { get; set; }
        public bool Deleting { get; set; }
        public int ServiceId { get; set; }
        public int CashboxId { get; set; }
        public int WarehouseId { get; set; }

        public virtual Cashbox Cashbox { get; set; }
        public virtual TypeOfService Service { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
    }
}
