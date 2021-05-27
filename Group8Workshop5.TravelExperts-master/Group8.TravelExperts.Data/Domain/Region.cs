using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Region
    {
        public Region()
        {
            BoDetOlds = new HashSet<BoDetOld>();
        }

        public string RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<BoDetOld> BoDetOlds { get; set; }
    }
}
