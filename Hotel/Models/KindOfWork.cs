using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class KindOfWork
    {
        public int IdKindOfWork { get; set; }
        public string CleaningType { get; set; }
        public bool Deleting { get; set; }
    }
}
