using Group8.TravelExperts.Data.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RickyTestApp.Models;
using System;
using System.Linq;

namespace RickyTestApp.Controllers
{
    //Ricky wrote this code.
    public class PurchasesController : Controller
    {
        /// <summary>
        /// View for displaying customer's orders and amount owing.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Index()
        {
            //First get all packages customer has ordered, then pass to ViewData.
            var packagesPurchased = BookingDetailsManager.GetPurchasedPackages((int)TempData.Peek("CustomerId"));

            ViewData["Packages"] = packagesPurchased.Select(pkg => new PurchaseViewModel
            {
                BookingDetailId = pkg.BookingDetailId,
                BookingNo = pkg.BookingNo,
                Destination = pkg.Destination,
                IsPaid = pkg.IsPaid,
                PkgName = pkg.PkgName,
                ProdName = pkg.ProdName,
                SupName = pkg.SupName,
                TotalPrice = pkg.TotalPrice,
                TripEnd = pkg.TripEnd,
                TripStart = pkg.TripStart,
                Discount = pkg.Discount
            });

            //Then get all products customer has ordered, then pass to ViewData.
            var productsPurchased = BookingDetailsManager.GetPurchasedProducts((int)TempData.Peek("CustomerId"));

            ViewData["Products"] = productsPurchased.Select(prod => new PurchaseViewModel
            {
                BookingDetailId = prod.BookingDetailId,
                BookingNo = prod.BookingNo,
                Destination = prod.Destination,
                IsPaid = prod.IsPaid,
                PkgName = prod.PkgName,
                ProdName = prod.ProdName,
                SupName = prod.SupName,
                TotalPrice = prod.TotalPrice,
                TripEnd = prod.TripEnd,
                TripStart = prod.TripStart,
                Discount = null
            });

            //Then calculate customer's amount owing, and pass to TempData.
            TempData["Amount Owing"] = BookingDetailsManager.GetTotalOwing((int)TempData.Peek("CustomerId"));

            return View();
        }

        /// <summary>
        /// Remove a product record from BookingsDetails
        /// </summary>
        /// <param name="bookingDetailsId"></param>
        /// <param name="prodName"></param>
        /// <param name="supName"></param>
        /// <param name="tripStart"></param>
        /// <returns></returns>
        public ActionResult CancelProductOrder(int bookingDetailsId, string prodName, string supName, DateTime tripStart)
        {
            //Calculate number of days between today and trip start date.
            //If under 4 days, don't allwow cancel.
            //4 days, because: if trip starts Monday, don't allow user to cancel on Friday night.
            DateTime today = DateTime.Today;
            int daysUntilTripStart = (tripStart - today).Days;
            if (daysUntilTripStart < 4)
                TempData["msg"] = "<script>alert('Today is too close to the trip start date. Please contact your agent.');</script>";

            else
            {
                try
                {
                    BookingDetailsManager.DeleteOrder(bookingDetailsId);
                    TempData["msg"] = "<script>alert('Your order for " + prodName + " provided by " + supName + " has been canceled.');</script>";
                }
                catch
                {
                    TempData["msg"] = "<script>alert('An issue occured when cancelling your order. Please try again later or contact your agent.');</script>";
                }
            }

            return RedirectToAction("Index", "Purchases");
        }

        /// <summary>
        /// Remove a package record from BookingsDetails
        /// </summary>
        /// <param name="bookingDetailsId"></param>
        /// <param name="pkgName"></param>
        /// <param name="tripStart"></param>
        /// <returns></returns>
        public ActionResult CancelPackageOrder(int bookingDetailsId, string pkgName, DateTime tripStart)
        {
            //Calculate number of days between today and trip start date.
            //If under 4 days, don't allwow cancel.
            //4 days, because: if trip starts Monday, don't allow user to cancel on Friday night.
            DateTime today = DateTime.Today;
            int daysUntilTripStart = (tripStart - today).Days;
            if (daysUntilTripStart < 4)
                TempData["msg"] = "<script>alert('Today is too close to the trip start date. Please contact your agent.');</script>";

            else
            {
                try
                {
                    BookingDetailsManager.DeleteOrder(bookingDetailsId);
                    TempData["msg"] = "<script>alert('Your order for " + pkgName + " has been canceled.');</script>";
                }
                catch
                {
                    TempData["msg"] = "<script>alert('An issue occured when cancelling your order. Please try again later or contact your agent.');</script>";
                }
            }

            return RedirectToAction("Index", "Purchases");
        }

        /// <summary>
        /// Changes the status of ISPAID to REFUND REQUESTED
        /// </summary>
        /// <param name="bookingDetailsId"></param>
        /// <returns></returns>
        public ActionResult RequestRefund(int bookingDetailsId)
        {
            try
            {
                BookingDetailsManager.RequestRefund(bookingDetailsId);
                TempData["msg"] = "<script>alert('Your request for a refund has been submitted.');</script>";
            }
            catch
            {
                TempData["msg"] = "<script>alert('An issue occured when requesting your refund. Please try again later or contact your agent.');</script>";
            }

            return RedirectToAction("Index", "Purchases");
        }

        public ActionResult ApplyDiscount(int bookingDetailsId)
        {
            BookingDetailsManager.ApplyDiscount((int)TempData.Peek("CustomerId"), bookingDetailsId);
                
            return RedirectToAction("Index", "Purchases");
        }
    }
}
