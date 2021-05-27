using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    //Ricky added this code.
    
    public partial class ProductsDisplayed
    {
        public int ProdDisplayId { get; set; }
        public string ProdName { get; set; }
        public string SupName { get; set; }
        public string Destination { get; set; }
        public DateTime? TripStart { get; set; }
        public DateTime? TripEnd { get; set; }
        public decimal? BasePrice { get; set; }
        public string FeeName { get; set; }
        public decimal? FeeAmt { get; set; }
    }

    public class ProductsDisplayedManager
    {
        /// <summary>
        /// Gets products being sold to be displayed.
        /// </summary>
        /// <returns></returns>
        public static List<PnPViewModel> GetAllProductsDisplayed()
        {
            TravelExpertsContext context = new TravelExpertsContext();

            var query = from products in context.ProductsDisplayeds
                        orderby products.TripStart
                        select new PnPViewModel
                        {
                            PkgName = null,
                            ProdName = products.ProdName,
                            SupName = products.SupName,
                            Destination = products.Destination,
                            TripStart = products.TripStart,
                            TripEnd = products.TripEnd,
                            BasePrice = products.BasePrice,
                            FeeName = products.FeeName,
                            FeeAmt = products.FeeAmt,
                            TotalPrice = products.BasePrice.GetValueOrDefault(0) + products.FeeAmt.GetValueOrDefault(0)
                        };

            List<PnPViewModel> displayedProductsList = new List<PnPViewModel>();

            foreach (PnPViewModel product in query)
            {
                displayedProductsList.Add(product);
            }

            return displayedProductsList;
        }
    }
}
