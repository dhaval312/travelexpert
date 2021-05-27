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
    public class IndexModel : PageModel
    {
        private readonly Group8.TravelExperts.Data.Domain.TravelExpertsContext _context;

        public IndexModel(Group8.TravelExperts.Data.Domain.TravelExpertsContext context)
        {
            _context = context;
        }

        public IList<BookingDetail> BookingDetail { get;set; }

        public async Task OnGetAsync()
        {
            BookingDetail = await _context.BookingDetails
                .Include(b => b.Booking).ToListAsync();
        }
    }
}
