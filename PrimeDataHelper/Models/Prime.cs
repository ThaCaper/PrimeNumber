using System;
using System.Collections.Generic;

#nullable disable

namespace PrimeDataHelper.Models
{
    public partial class Prime
    {
        public int Id { get; set; }
        public int? Input { get; set; }
        public bool? IsPrime { get; set; }
        public int? Occurrences { get; set; }
    }
}
