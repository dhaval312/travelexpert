using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Product
    {
        public Product()
        {
            ProductsSuppliers = new HashSet<ProductsSupplier>();
            PsOlds = new HashSet<PsOld>();
        }

        public int ProductId { get; set; }
        public string ProdName { get; set; }

        public virtual ICollection<ProductsSupplier> ProductsSuppliers { get; set; }
        public virtual ICollection<PsOld> PsOlds { get; set; }
    }
}
