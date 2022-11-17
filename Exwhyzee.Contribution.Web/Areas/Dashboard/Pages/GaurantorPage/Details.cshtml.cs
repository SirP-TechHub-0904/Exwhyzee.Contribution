using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.GaurantorPage
{
    public class DetailsModel : PageModel
    {
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public DetailsModel(Exwhyzee.Contribution.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public GaurantorAccount GaurantorAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GaurantorAccount = await _context.GaurantorAccounts
                .Include(g => g.Gaurantor)
                .Include(g => g.Profile).FirstOrDefaultAsync(m => m.Id == id);

            if (GaurantorAccount == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
