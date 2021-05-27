using System.ComponentModel.DataAnnotations;

namespace RickyTestApp.Models
{
    //Ricky wrote this code for organizing login page.
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}
