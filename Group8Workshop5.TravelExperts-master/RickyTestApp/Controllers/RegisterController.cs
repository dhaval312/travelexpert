using Group8.TravelExperts.Data.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
//Dhaval wrote this code 
namespace RickyTestApp.Controllers
{
    public class RegisterController : Controller
    {
        //Ricky added select lists to this code.
        public ActionResult RegisterDetails()
        {
            ViewBag.cust = CustomerManager.Registration();
            List<SelectListItem> securityQuestions = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "What is your mother's maiden name?",
                    Value = "What is your mother's maiden name?"
                },
                new SelectListItem
                {
                    Text = "Where did you attend high school?",
                    Value = "Where did you attend high school?"
                },
                new SelectListItem
                {
                    Text = "Why is Eric always dressed so nicely?",
                    Value = "Why is Eric always dressed so nicely?"
                },
                new SelectListItem
                {
                    Text = "What is your favourite TV show?",
                    Value = "What is your favourite TV show?"
                }
            };

            ViewBag.SecurityQuestions = securityQuestions;

            List<SelectListItem> provinces = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "AB",
                    Value = "AB"
                },
                new SelectListItem
                {
                    Text = "BC",
                    Value = "BC"
                },
                new SelectListItem
                {
                    Text = "MB",
                    Value = "MB"
                },
                new SelectListItem
                {
                    Text = "NB",
                    Value = "NB"
                },
                new SelectListItem
                {
                    Text = "NL",
                    Value = "NL"
                },
                new SelectListItem
                {
                    Text = "NS",
                    Value = "NS"
                },
                new SelectListItem
                {
                    Text = "NT",
                    Value = "NT"
                },
                new SelectListItem
                {
                    Text = "NU",
                    Value = "NU"
                },
                new SelectListItem
                {
                    Text = "ON",
                    Value = "ON"
                },
                new SelectListItem
                {
                    Text = "PE",
                    Value = "PE"
                },
                new SelectListItem
                {
                    Text = "QC",
                    Value = "QC"
                },
                new SelectListItem
                {
                    Text = "SK",
                    Value = "SK"
                },
                new SelectListItem
                {
                    Text = "YK",
                    Value = "YK"
                }
            };
            ViewBag.Provinces = provinces;

            return View();

        }

        [HttpPost]

        public ActionResult RegisterDetails(Customer c)
        {
            List<SelectListItem> securityQuestions = new List<SelectListItem>()
                {
                    new SelectListItem
                    {
                        Text = "What is your mother's maiden name?",
                        Value = "What is your mother's maiden name?"
                    },
                    new SelectListItem
                    {
                        Text = "Where did you attend high school?",
                        Value = "Where did you attend high school?"
                    },
                    new SelectListItem
                    {
                        Text = "Why is Eric always dressed so nicely?",
                        Value = "Why is Eric always dressed so nicely?"
                    },
                    new SelectListItem
                    {
                        Text = "What is your favourite TV show?",
                        Value = "What is your favourite TV show?"
                    }
                };

            ViewBag.SecurityQuestions = securityQuestions;

            List<SelectListItem> provinces = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "AB",
                    Value = "AB"
                },
                new SelectListItem
                {
                    Text = "BC",
                    Value = "BC"
                },
                new SelectListItem
                {
                    Text = "MB",
                    Value = "MB"
                },
                new SelectListItem
                {
                    Text = "NB",
                    Value = "NB"
                },
                new SelectListItem
                {
                    Text = "NL",
                    Value = "NL"
                },
                new SelectListItem
                {
                    Text = "NS",
                    Value = "NS"
                },
                new SelectListItem
                {
                    Text = "NT",
                    Value = "NT"
                },
                new SelectListItem
                {
                    Text = "NU",
                    Value = "NU"
                },
                new SelectListItem
                {
                    Text = "ON",
                    Value = "ON"
                },
                new SelectListItem
                {
                    Text = "PE",
                    Value = "PE"
                },
                new SelectListItem
                {
                    Text = "QC",
                    Value = "QC"
                },
                new SelectListItem
                {
                    Text = "SK",
                    Value = "SK"
                },
                new SelectListItem
                {
                    Text = "YK",
                    Value = "YK"
                }
            };
            ViewBag.Provinces = provinces;

            if (ModelState.IsValid)
            {
                if (CustomersAuthenticationManager.UsernameIsTaken(c.CustomersAuthentication.Username) == true)
                {
                    ViewBag.Message = "User Name " + c.CustomersAuthentication.Username + " already exists";
                    return View();
                }
                else
                {
                    try
                    {
                        CustomerManager.Add(c);

                        TempData["LoginPrompt"] = "<script>alert('Your account has been created. You may log in with your username and password.');</script>";
                        return RedirectToAction("Login", "Account");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> provinces = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "AB",
                    Value = "AB"
                },
                new SelectListItem
                {
                    Text = "BC",
                    Value = "BC"
                },
                new SelectListItem
                {
                    Text = "MB",
                    Value = "MB"
                },
                new SelectListItem
                {
                    Text = "NB",
                    Value = "NB"
                },
                new SelectListItem
                {
                    Text = "NL",
                    Value = "NL"
                },
                new SelectListItem
                {
                    Text = "NS",
                    Value = "NS"
                },
                new SelectListItem
                {
                    Text = "NT",
                    Value = "NT"
                },
                new SelectListItem
                {
                    Text = "NU",
                    Value = "NU"
                },
                new SelectListItem
                {
                    Text = "ON",
                    Value = "ON"
                },
                new SelectListItem
                {
                    Text = "PE",
                    Value = "PE"
                },
                new SelectListItem
                {
                    Text = "QC",
                    Value = "QC"
                },
                new SelectListItem
                {
                    Text = "SK",
                    Value = "SK"
                },
                new SelectListItem
                {
                    Text = "YK",
                    Value = "YK"
                }
            };
            ViewBag.Provinces = provinces;

            Customer cust = CustomerManager.GetAuthenticatedCustomerByID(id);

            return View(cust);
        }



        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, Customer c)
        {
            List<SelectListItem> provinces = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "AB",
                    Value = "AB"
                },
                new SelectListItem
                {
                    Text = "BC",
                    Value = "BC"
                },
                new SelectListItem
                {
                    Text = "MB",
                    Value = "MB"
                },
                new SelectListItem
                {
                    Text = "NB",
                    Value = "NB"
                },
                new SelectListItem
                {
                    Text = "NL",
                    Value = "NL"
                },
                new SelectListItem
                {
                    Text = "NS",
                    Value = "NS"
                },
                new SelectListItem
                {
                    Text = "NT",
                    Value = "NT"
                },
                new SelectListItem
                {
                    Text = "NU",
                    Value = "NU"
                },
                new SelectListItem
                {
                    Text = "ON",
                    Value = "ON"
                },
                new SelectListItem
                {
                    Text = "PE",
                    Value = "PE"
                },
                new SelectListItem
                {
                    Text = "QC",
                    Value = "QC"
                },
                new SelectListItem
                {
                    Text = "SK",
                    Value = "SK"
                },
                new SelectListItem
                {
                    Text = "YK",
                    Value = "YK"
                }
            };
            ViewBag.Provinces = provinces; 
            
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerManager.Update(id, c);

                    return RedirectToAction("Index", "Home");
                }

                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult EditAuth(int id)
        {
            CustomersAuthentication cust = CustomersAuthenticationManager.GetByCustomerId(id);
            return View(cust);
        }
        [Authorize]
        public ActionResult EditAuth1(int id, string user, string oldp, string newp, string confnewp)
        {
            
                var msg = "<p ";

            if (newp == confnewp)
            {
                if (CustomersAuthenticationManager.CheckOldPasswordThenUpdate(id, user, oldp, newp) == true)
                    msg += "style='color:blue;'> Password changed successfully!</p>";
                else
                    msg += "style='color:red;'> Current password was entered incorrectly| Password was not updated.</p>";
            }
            else
            {
                msg += "style='color:red;'>Confirm password does not match | Password was not updated.</p>";
            }
            return Content(msg);
        }
    }
}


   


