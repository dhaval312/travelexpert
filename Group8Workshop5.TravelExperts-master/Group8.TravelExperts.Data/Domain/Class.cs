using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Class
    {
        public Class()
        {
            BoDetOlds = new HashSet<BoDetOld>();
        }

        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDesc { get; set; }

        public virtual ICollection<BoDetOld> BoDetOlds { get; set; }
    }
}
