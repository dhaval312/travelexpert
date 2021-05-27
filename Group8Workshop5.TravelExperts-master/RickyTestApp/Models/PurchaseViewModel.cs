using System;
using System.ComponentModel.DataAnnotations;

namespace RickyTestApp.Models
{
    //Ricky wrote this code for displaying orders.
    public class PurchaseViewModel
    {
        public int BookingDetailId { get; set; }
      
        [Display(Name = "Booking Number")]
        public string BookingNo { get; set; }
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
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Customer has paid")]
        public string IsPaid { get; set; }
        public decimal? Discount { get; set; }
    }
}
