using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public double? ItineraryNo { get; set; }
        public DateTime? TripStart { get; set; }
        public DateTime? TripEnd { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? AgencyCommission { get; set; }
        public int? BookingId { get; set; }
        public string Region { get; set; }
        public string Class { get; set; }
        public string FeeName { get; set; }
        public decimal? FeeAmt { get; set; }
        public string ProdName { get; set; }
        public string SupName { get; set; }
        public string PkgName { get; set; }
        public string IsPaid { get; set; }

        public virtual Booking Booking { get; set; }
    }

    //Ricky added this code.
    public class BookingDetailsManager
    {
        /// <summary>
        /// Get all packages customer has purchased.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static List<PurchaseModel> GetPurchasedPackages(int customerId)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            List<PurchaseModel> purchasedPackageList = new List<PurchaseModel>();

            decimal? discount = (from discounts in context.Discounts
                                 where discounts.CustomerId == customerId
                                 select discounts.DiscountPercent).FirstOrDefault();

            var query = from bookings in context.Bookings
                        join bookingDetails in context.BookingDetails on bookings.BookingId equals bookingDetails.BookingId
                        where bookings.CustomerId == customerId
                        where bookingDetails.ProdName == null
                        select new PurchaseModel { 
                            BookingDetailId = bookingDetails.BookingDetailId,
                            BookingNo = bookings.BookingNo,
                            PkgName = bookingDetails.PkgName,
                            ProdName = bookingDetails.ProdName,
                            SupName = bookingDetails.SupName,
                            Destination = bookingDetails.Destination,
                            TripStart = bookingDetails.TripStart,
                            TripEnd = bookingDetails.TripEnd,
                            TotalPrice = (decimal)(bookingDetails.BasePrice + bookingDetails.FeeAmt),
                            IsPaid = bookingDetails.IsPaid,
                            Discount = discount
                        };

            
            
            foreach (PurchaseModel package in query)
            {
                purchasedPackageList.Add(package);
            }

            return purchasedPackageList;
        }

        /// <summary>
        /// Get all products a customer has purchased.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static List<PurchaseModel> GetPurchasedProducts(int customerId)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            var query = from bookings in context.Bookings
                        join bookingDetails in context.BookingDetails on bookings.BookingId equals bookingDetails.BookingId
                        where bookings.CustomerId == customerId
                        where bookingDetails.PkgName == null
                        select new PurchaseModel
                        {
                            BookingDetailId = bookingDetails.BookingDetailId,
                            BookingNo = bookings.BookingNo,
                            PkgName = bookingDetails.PkgName,
                            ProdName = bookingDetails.ProdName,
                            SupName = bookingDetails.SupName,
                            Destination = bookingDetails.Destination,
                            TripStart = bookingDetails.TripStart,
                            TripEnd = bookingDetails.TripEnd,
                            TotalPrice = (decimal)(bookingDetails.BasePrice + bookingDetails.FeeAmt),
                            IsPaid = bookingDetails.IsPaid
                        };

            List<PurchaseModel> purchasedProductList = new List<PurchaseModel>();

            foreach (PurchaseModel product in query)
            {
                purchasedProductList.Add(product);
            }

            return purchasedProductList;
        }

        
        /// <summary>
        /// Get customer's amount owing.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static decimal GetTotalOwing(int customerId)
        {
            decimal unpaidBasePrices;
            decimal unpaidFees;

            TravelExpertsContext context = new TravelExpertsContext();

            var uBP = (from bookings in context.Bookings
                            join bookingDetails in context.BookingDetails on bookings.BookingId equals bookingDetails.BookingId
                       where bookings.CustomerId == customerId
                       where bookingDetails.IsPaid == "NO"
                       select bookingDetails.BasePrice).Sum();
            if (uBP == null)
                unpaidBasePrices = 0;
            else
                unpaidBasePrices = uBP.Value;

            var uF = (from bookings in context.Bookings
                      join bookingDetails in context.BookingDetails on bookings.BookingId equals bookingDetails.BookingId
                      where bookings.CustomerId == customerId
                      where bookingDetails.IsPaid == "NO"
                      select bookingDetails.FeeAmt).Sum();

            if (uF == null)
                unpaidFees = 0;
            else
                unpaidFees = uF.Value;

            decimal unpaidTotal = unpaidBasePrices + unpaidFees;

            return unpaidTotal;
        }

        public static void ApplyDiscount(int customerId, int bookingDetailsId)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            string executor = "EXEC spStopDiscount " + customerId.ToString() + "," + bookingDetailsId.ToString();

            var x = context.BookingDetails.FromSqlRaw(executor).ToList();
        }

        /// <summary>
        /// Update ISPAID column to show REFUND REQUESTED
        /// </summary>
        /// <param name="bookingDetailsId"></param>
        public static void RequestRefund(int bookingDetailsId)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            var target = (from bookingDetails in context.BookingDetails
                          where bookingDetails.BookingDetailId == bookingDetailsId
                          select bookingDetails).SingleOrDefault();

            target.IsPaid = "REFUND REQUESTED";

            context.SaveChanges();
        }

        /// <summary>
        /// Add a package record to BookingDetails
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pkgName"></param>
        /// <param name="basePrice"></param>
        /// <param name="tripStart"></param>
        /// <param name="tripEnd"></param>
        public static void AddPackageOrder(int customerId, string pkgName, decimal basePrice, DateTime tripStart, DateTime tripEnd)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            Booking booking = new Booking
            {
                BookingDate = null,
                BookingNo = BookingNoGenerator.GenerateBookingNo(),
                CustomerId = customerId,
                PackageId = 1,
                TripTypeId = "B",
                TravelerCount = null
            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            BookingDetail bookingDetail = new BookingDetail
            {
                ItineraryNo = null,
                TripStart = tripStart,
                TripEnd = tripEnd,
                Description = null,
                Destination = null,
                BasePrice = basePrice,
                AgencyCommission = null,
                BookingId = booking.BookingId,
                Region = null,
                Class = null,
                FeeName = "Booking Charge",
                FeeAmt = 25.0m,
                ProdName = null,
                SupName = null,
                PkgName = pkgName,
                IsPaid = "NO"
            };

            context.BookingDetails.Add(bookingDetail);
            context.SaveChanges();
        }

        /// <summary>
        /// Add a product to BookingDetails
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="prodName"></param>
        /// <param name="supName"></param>
        /// <param name="destination"></param>
        /// <param name="basePrice"></param>
        /// <param name="feeName"></param>
        /// <param name="feeAmt"></param>
        /// <param name="tripStart"></param>
        /// <param name="tripEnd"></param>
        public static void AddProductOrder(int customerId, string prodName, string supName, string destination, decimal basePrice, string feeName, decimal feeAmt, DateTime tripStart, DateTime tripEnd)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            Booking booking = new Booking
            {
                BookingDate = null,
                BookingNo = BookingNoGenerator.GenerateBookingNo(),
                CustomerId = customerId,
                PackageId = 1,
                TripTypeId = "B",
                TravelerCount = null
            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            BookingDetail bookingDetail = new BookingDetail
            {
                ItineraryNo = null,
                TripStart = tripStart,
                TripEnd = tripEnd,
                Description = null,
                Destination = destination,
                BasePrice = basePrice,
                AgencyCommission = null,
                BookingId = booking.BookingId,
                Region = null,
                Class = null,
                FeeName = feeName,
                FeeAmt = feeAmt,
                ProdName = prodName,
                SupName = supName,
                PkgName = null,
                IsPaid = "NO"
            };

            context.BookingDetails.Add(bookingDetail);
            context.SaveChanges();
        }

        /// <summary>
        /// Remove an record from BookingDetails
        /// </summary>
        /// <param name="bookingDetailsId"></param>
        public static void DeleteOrder(int bookingDetailsId)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            var target = from bookingDetails in context.BookingDetails
                         where bookingDetails.BookingDetailId == bookingDetailsId
                         select bookingDetails;

            List<BookingDetail> list = new List<BookingDetail>();

            foreach (BookingDetail deet in target)
                list.Add(deet);

            context.BookingDetails.Remove(list[0]);
            context.SaveChanges();
        }
    }
}
