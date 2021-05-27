using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group8.TravelExperts.Data.Domain;

namespace Group8.TravelExperts.App.Pages.BookingDetails
{
    public class DetailsModel : PageModel
    {
        private readonly Group8.TravelExperts.Data.Domain.TravelExpertsContext _context;

        public DetailsModel(Group8.TravelExperts.Data.Domain.TravelExpertsContext context)
        {
            _context = context;
        }

        public BookingDetail BookingDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookingDetail = await _context.BookingDetails
                .Include(b => b.Booking).FirstOrDefaultAsync(m => m.BookingDetailId == id);

            if (BookingDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
