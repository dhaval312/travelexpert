using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Affiliation
    {
        public Affiliation()
        {
            SupplierContacts = new HashSet<SupplierContact>();
        }

        public string AffilitationId { get; set; }
        public string AffName { get; set; }
        public string AffDesc { get; set; }

        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }
    }
}
