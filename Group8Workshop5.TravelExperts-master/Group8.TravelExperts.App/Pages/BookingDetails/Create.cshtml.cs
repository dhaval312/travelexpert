using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Group8.TravelExperts.Data.Domain;

namespace Group8.TravelExperts.App.Pages.BookingDetails
{
    public class CreateModel : PageModel
    {
        private readonly Group8.TravelExperts.Data.Domain.TravelExpertsContext _context;

        public CreateModel(Group8.TravelExperts.Data.Domain.TravelExpertsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            return Page();
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookingDetails.Add(BookingDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
