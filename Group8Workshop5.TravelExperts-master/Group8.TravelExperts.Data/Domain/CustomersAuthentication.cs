using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace Group8.TravelExperts.Data.Domain
{
    //Stephen and Tristen added these validations
    public partial class CustomersAuthentication
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(25, ErrorMessage = "Please enter a username between 5 and 25 characters.")]
        [MinLength(5, ErrorMessage = "Please enter a username between 5 and 25 characters.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please re-enter your password.")]
        [Compare("Password", ErrorMessage = "Passwords do not match. Please try again.")]
        public string ConfirmPassword { get; set; }
        public string SecurityQuestion1 { get; set; }
        [Required(ErrorMessage = "Please submit an answer.")]
        public string SQAnswer1 { get; set; }
        public virtual Customer Customer { get; set; }
    }

    //Ricky added manager and the first three methods.other three methods is by dhaval
    public class CustomersAuthenticationManager
    {
        /// <summary>
        /// If username/password is correct, return username, customerId and customer's first name
        /// to be stored in temp data.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static ClaimsModel Authenticate(string username, string password)
        {
            TravelExpertsContext context = new TravelExpertsContext();
            var user = context.CustomersAuthentications.SingleOrDefault(usr => usr.Username == username && usr.Password == password);

            if (user != null)
            {
                int customerId = user.CustomerId;

                var customer = context.Customers.SingleOrDefault(cust => cust.CustomerId == customerId);
                string fName = customer.CustFirstName;

                ClaimsModel claims = new ClaimsModel()
                {
                    Username = username,
                    CustomerId = customerId,
                    CustFirstName = fName
                };

                return claims;
            }
            else
                return null;  
        }

        /// <summary>
        /// If user is requesting password reset, pull their security question to display to user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetSecurityQuestion(string username)
        {
            TravelExpertsContext context = new TravelExpertsContext();

            CustomersAuthentication target = context.CustomersAuthentications.SingleOrDefault(c => c.Username == username);

            string question;

            if (target == null)
                question = null;
            else
                question = target.SecurityQuestion1;

            return question;
        }

        /// <summary>
        /// Determines whether user's submitted to security question is correct.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static bool SecurityQuestionAnsweredCorrect(string username, string answer)
        {
            TravelExpertsContext context = new TravelExpertsContext();
            CustomersAuthentication target = context.CustomersAuthentications.SingleOrDefault(c => c.Username == username);

            if (target.SQAnswer1 == answer)
                return true;
            else
                return false;
        }
        /// <summary>
        /// To get Customer Authentication object by id
        /// </summary>
        /// <param name="id">Customerid</param>
        /// <returns></returns>
        public static CustomersAuthentication GetByCustomerId(int id)
        {
            var context = new TravelExpertsContext();
            var cust = context.CustomersAuthentications.SingleOrDefault(c => c.CustomerId == id);
            
            return cust;
        }
        /// <summary>
        /// to check the username written is not taken by previous users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UsernameIsTaken(string user)
        {
            var context = new TravelExpertsContext();
            var ca = context.CustomersAuthentications.ToList();
            var usernames = ca.Select(a => a.Username).Distinct();
            if (usernames.Contains(user, StringComparer.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }
        /// <summary>
        /// while resetting the password check the old password is correct or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="oldp"></param>
        /// <param name="newp"></param>
        /// <returns></returns>
        public static bool CheckOldPasswordThenUpdate(int id, string user, string oldp, string newp)
        {
            var context = new TravelExpertsContext();
            var u = context.CustomersAuthentications.SingleOrDefault(cp => cp.CustomerId == id);
         
                if (u.Password == oldp)
                {
                    u.Username = user;
                    u.Password = newp;
                    /*u.Password = confnewp*/;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
           
        }
    }         
}