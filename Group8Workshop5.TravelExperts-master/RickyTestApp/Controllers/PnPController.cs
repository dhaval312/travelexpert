using Group8.TravelExperts.Data.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace RickyTestApp.Controllers
{
    //Ricky wrote this code.
    public class PnPController : Controller
    {
        /// <summary>
        /// View for displaying products and packages being sold.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Frist get all packages to be displayed, and pass to ViewData.
            var packagesToSell = PackageManager.GetAllPackages();

            ViewData["Packages To Sell"] = packagesToSell.Select(pkg => new PnPViewModel
            {
                PkgName = pkg.PkgName,
                ProdName = pkg.ProdName,
                SupName = pkg.SupName,
                Destination = pkg.Destination,
                TripStart = pkg.TripStart,
                TripEnd = pkg.TripEnd,
                BasePrice = pkg.BasePrice,
                FeeName = pkg.FeeName,
                FeeAmt = pkg.FeeAmt,
                TotalPrice = pkg.TotalPrice
            });

            //Then get all products to be displayed, and pass to ViewData.
            var productsToSell = ProductsDisplayedManager.GetAllProductsDisplayed();

            ViewData["Products To Sell"] = productsToSell.Select(prod => new PnPViewModel
            {
                PkgName = prod.PkgName,
                ProdName = prod.ProdName,
                SupName = prod.SupName,
                Destination = prod.Destination,
                TripStart = prod.TripStart,
                TripEnd = prod.TripEnd,
                BasePrice = prod.BasePrice,
                FeeName = prod.FeeName,
                FeeAmt = prod.FeeAmt,
                TotalPrice = prod.TotalPrice
            });

            return View();
        }

        /// <summary>
        /// Add a package to customer's list of ordered packages, then redirect to orders spage.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="pkgName"></param>
        /// <param name="basePrice"></param>
        /// <param name="tripStart"></param>
        /// <param name="tripEnd"></param>
        /// <returns></returns>
        public ActionResult OrderPackage(int customerId, string pkgName, decimal basePrice, DateTime tripStart, DateTime tripEnd)
        {
            try
            {
                BookingDetailsManager.AddPackageOrder(customerId, pkgName, basePrice, tripStart, tripEnd);
                return RedirectToAction("Index", "Purchases");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Add a product to customer's list of ordered products, then redirect to orders spage.
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
        /// <returns></returns>
        public ActionResult OrderProduct(int customerId, string prodName, string supName, string destination, decimal basePrice, string feeName, decimal feeAmt, DateTime tripStart, DateTime tripEnd)
        {
            try
            {
                BookingDetailsManager.AddProductOrder(customerId, prodName, supName, destination, basePrice, feeName, feeAmt, tripStart, tripEnd);
                return RedirectToAction("Index", "Purchases");
            }
            catch
            {
                return View();
            }
        }
    }
 }

