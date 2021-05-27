using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CreditCards = new HashSet<CreditCard>();
            CustomersRewards = new HashSet<CustomersReward>();
        }

        //Tristen added these validations

        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        public string CustFirstName { get; set; }
        [Required(ErrorMessage = "Please enter you last name.")]
        public string CustLastName { get; set; }
        [Required(ErrorMessage = "Please enter your address.")]
        public string CustAddress { get; set; }
        [Required(ErrorMessage = "Please enter your city.")]
        public string CustCity { get; set; }
        [Required(ErrorMessage = "Please enter your Province code.")]
        //[MinLength(2)]
        public string CustProv { get; set; }
        [Required(ErrorMessage = "Please enter your Canadian Postal Code.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$", ErrorMessage = "Please enter a valid Canadian Postal Code. For example: A1B 2C3")] // ~ TS
        public string CustPostal { get; set; }
        [Required(ErrorMessage = "Please enter your phone number.")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Please enter a valid phone number. For example: (555)-555-5555")] // ~ TS
        public string CustHomePhone { get; set; }

        public string CustBusPhone { get; set; }

        public string CustFax { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please enter a valid email address. For example: Example@email.com")] // ~ TS
        public string CustEmail { get; set; }
        public int? AgentId { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual CustomersAuthentication CustomersAuthentication { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
    //Dhaval wrote this code
    public class CustomerManager
    {
        //to get all customers 
        public static List<Customer> Registration()
        {
            var context = new TravelExpertsContext();
            var customers = context.Customers.Include(c => c.CustomersAuthentication).ToList();
            return customers;
        }
        //to add a new customer
        public static void Add(Customer c)
        {
            var context = new TravelExpertsContext();
            context.Customers.Add(c);
            context.SaveChanges();
        }
        //find customer with custome authentication details
        public static Customer GetAuthenticatedCustomerByID(int id)
        {
            var context = new TravelExpertsContext();
            var cust = context.Customers.Include(ca => ca.CustomersAuthentication).SingleOrDefault(c => c.CustomerId == id);
            return cust;
        }
        //update customer
        public static void Update(int id, Customer c)
        {
            var context = new TravelExpertsContext();
            var u = context.Customers.SingleOrDefault(cp => cp.CustomerId == id);

            u.CustFirstName = c.CustFirstName;
            u.CustLastName = c.CustLastName;
            u.CustAddress = c.CustAddress;
            u.CustCity = c.CustCity;
            u.CustProv = c.CustProv;
            u.CustPostal = c.CustPostal;
            u.CustHomePhone = c.CustHomePhone;
            u.CustBusPhone = c.CustBusPhone;
            u.CustFax = c.CustFax;
            u.CustEmail = c.CustEmail;

            context.SaveChanges();
        }
    }
}
