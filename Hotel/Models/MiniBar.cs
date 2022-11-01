using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class MiniBar
    {
        public MiniBar()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        public int IdMiniBar { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public bool Deleting { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
