using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Fee
    {
        public Fee()
        {
            BoDetOlds = new HashSet<BoDetOld>();
        }

        public string FeeId { get; set; }
        public string FeeName { get; set; }
        public decimal FeeAmt { get; set; }
        public string FeeDesc { get; set; }

        public virtual ICollection<BoDetOld> BoDetOlds { get; set; }
    }
}
