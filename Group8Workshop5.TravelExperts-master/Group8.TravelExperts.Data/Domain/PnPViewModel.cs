using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group8.TravelExperts.Data.Domain
{
    //Ricky added this code. Model for getting and displaying packages and products to be sold.
    public class PnPViewModel
    {
        [Display(Name = "Package Name")]
        public string PkgName { get; set; }
        [Display(Name = "Product Type")]
        public string ProdName { get; set; }
        [Display(Name = "Provided by")]
        public string SupName { get; set; }
        public string Destination { get; set; }
        [Display(Name = "Trip Start Date")]
        [DataType(DataType.Date)]
        public DateTime? TripStart { get; set; }
        [Display(Name = "Trip End Date")]
        [DataType(DataType.Date)]
        public DateTime? TripEnd { get; set; }
        [Display(Name = "Base Price")]
        public decimal? BasePrice { get; set; }
        [Display(Name = "Fee type")]
        public string FeeName { get; set; }
        [Display(Name = "Fee Amount")]
        public decimal? FeeAmt { get; set; }
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

    }
}
