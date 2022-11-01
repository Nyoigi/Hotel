using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class Maid
    {
        public int IdMaids { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public bool Deleting { get; set; }
    }
}
