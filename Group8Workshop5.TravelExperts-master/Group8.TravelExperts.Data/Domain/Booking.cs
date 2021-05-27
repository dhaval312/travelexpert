using System;
using System.Collections.Generic;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Booking
    {
        public Booking()
        {
            BoDetOlds = new HashSet<BoDetOld>();
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingNo { get; set; }
        public double? TravelerCount { get; set; }
        public int? CustomerId { get; set; }
        public string TripTypeId { get; set; }
        public int? PackageId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Package Package { get; set; }
        public virtual TripType TripType { get; set; }
        public virtual ICollection<BoDetOld> BoDetOlds { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
