using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class TypeOfService
    {
        public TypeOfService()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int IdService { get; set; }
        public string ServiceType { get; set; }
        public bool Deleting { get; set; }

        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
