#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class CustomersReward
    {
        public int CustomerId { get; set; }
        public int RewardId { get; set; }
        public string RwdNumber { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Reward Reward { get; set; }
    }
}
