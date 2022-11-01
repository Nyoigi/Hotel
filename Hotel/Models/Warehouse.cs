using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int IdWarehouse { get; set; }
        public int MiniBarId { get; set; }
        public bool Deleting { get; set; }

        public virtual MiniBar MiniBar { get; set; }
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
