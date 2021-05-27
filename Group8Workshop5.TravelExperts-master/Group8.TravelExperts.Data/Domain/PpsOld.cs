using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class PpsOld
    {
        public int PackageId { get; set; }
        public int ProductSupplierId { get; set; }

        public virtual Package Package { get; set; }
        public virtual PsOld ProductSupplier { get; set; }
    }
}
