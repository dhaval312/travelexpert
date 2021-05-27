using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group8.TravelExperts.Data.Domain
{
    /// <summary>
    /// Model for pulling security question info.
    /// </summary>
    public class SecurityQuestionViewModel
    {
        public string SecurityQuestion1 { get; set; }
        public string SQAnswer1 { get; set; }
        [Required(ErrorMessage = "PLEASE RE-ENTER YOUR PASSWORD")]
        [Compare("SQAnswer1", ErrorMessage = "Answer incorrect; please try again.")]
        public string Attempt { get; set; }
    }
}
