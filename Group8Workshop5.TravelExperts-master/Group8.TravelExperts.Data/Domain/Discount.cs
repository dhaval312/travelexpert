using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Discount
    {
        public int CustomerId { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
