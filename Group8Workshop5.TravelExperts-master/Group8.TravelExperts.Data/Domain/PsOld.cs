using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class PsOld
    {
        public PsOld()
        {
            BoDetOlds = new HashSet<BoDetOld>();
            PpsOlds = new HashSet<PpsOld>();
        }

        public int ProductSupplierId { get; set; }
        public int? ProductId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<BoDetOld> BoDetOlds { get; set; }
        public virtual ICollection<PpsOld> PpsOlds { get; set; }
    }
}
