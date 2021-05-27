using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Agent
    {
        public Agent()
        {
            Customers = new HashSet<Customer>();
            CustsOlds = new HashSet<CustsOld>();
        }

        public int AgentId { get; set; }
        public string AgtFirstName { get; set; }
        public string AgtMiddleInitial { get; set; }
        public string AgtLastName { get; set; }
        public string AgtBusPhone { get; set; }
        public string AgtEmail { get; set; }
        public string AgtPosition { get; set; }
        public int? AgencyId { get; set; }

        public virtual Agency Agency { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<CustsOld> CustsOlds { get; set; }
    }
}
