using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group8.TravelExperts.Data.Domain;

namespace Group8.TravelExperts.App.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly Group8.TravelExperts.Data.Domain.TravelExpertsContext _context;

        public DetailsModel(Group8.TravelExperts.Data.Domain.TravelExpertsContext context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _context.Suppliers.FirstOrDefaultAsync(m => m.SupplierId == id);

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
