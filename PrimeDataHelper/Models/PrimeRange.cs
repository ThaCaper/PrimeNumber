using System;
using System.Collections.Generic;

#nullable disable

namespace PrimeDataHelper.Models
{
    public partial class PrimeRange
    {
        public int Id { get; set; }
        public int? Input1 { get; set; }
        public int? Input2 { get; set; }
        public int? NumOfPrimes { get; set; }
        public int? Occurrences { get; set; }
    }
}
