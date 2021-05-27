using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class ProductsSupplier
    {
        public ProductsSupplier()
        {
            PackagesProductsSuppliers = new HashSet<PackagesProductsSupplier>();
        }

        public int ProductId { get; set; }
        public int SupplierId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }
    }
}
