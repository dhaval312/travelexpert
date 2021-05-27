using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
            PackagesProductsSuppliers = new HashSet<PackagesProductsSupplier>();
            PpsOlds = new HashSet<PpsOld>();
        }

        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime? PkgStartDate { get; set; }
        public DateTime? PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }
        public virtual ICollection<PpsOld> PpsOlds { get; set; }
    }

    //Ricky added this code.
    public class PackageManager
    {
        /// <summary>
        /// Gets packages being offered to display.
        /// </summary>
        /// <returns></returns>
        public static List<PnPViewModel> GetAllPackages()
        {
            TravelExpertsContext context = new TravelExpertsContext();

            var query = from packages in context.Packages
                        orderby packages.PkgStartDate
                        select new PnPViewModel
                        {
                            PkgName = packages.PkgName,
                            ProdName = null,
                            SupName = null,
                            Destination = null,
                            TripStart = packages.PkgStartDate,
                            TripEnd = packages.PkgEndDate,
                            BasePrice = packages.PkgBasePrice,
                            FeeName = "Booking Charge",
                            FeeAmt = 25.0m,
                            TotalPrice = packages.PkgBasePrice + 25
                        };

            List<PnPViewModel> displayedPackgesList = new List<PnPViewModel>();

            foreach (PnPViewModel package in query)
            {
                displayedPackgesList.Add(package);
            }

            return displayedPackgesList;
        }
    }
}
