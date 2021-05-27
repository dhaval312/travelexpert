using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group8.TravelExperts.Data.Domain;

namespace Group8.TravelExperts.App.Pages.BookingDetails
{
    public class EditModel : PageModel
    {
        private readonly Group8.TravelExperts.Data.Domain.TravelExpertsContext _context;

        public EditModel(Group8.TravelExperts.Data.Domain.TravelExpertsContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(BookingDetail.BookingDetailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingDetailExists(int id)
        {
            return _context.BookingDetails.Any(e => e.BookingDetailId == id);
        }
    }
}
