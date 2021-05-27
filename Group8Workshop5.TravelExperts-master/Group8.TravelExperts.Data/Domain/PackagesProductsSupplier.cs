using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class PackagesProductsSupplier
    {
        public int PackageId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }

        public virtual Package Package { get; set; }
        public virtual ProductsSupplier ProductsSupplier { get; set; }
    }
}
