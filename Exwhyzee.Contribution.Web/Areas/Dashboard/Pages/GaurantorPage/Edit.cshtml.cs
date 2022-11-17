using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.GaurantorPage
{
    public class EditModel : PageModel
    {
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public EditModel(Exwhyzee.Contribution.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["GaurantorId"] = new SelectList(_context.Set<Profile>(), "Id", "Id");
           ViewData["ProfileId"] = new SelectList(_context.Set<Profile>(), "Id", "Id");
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

            _context.Attach(GaurantorAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                TempData["aasuccess"] = "Updated successfully";

            }
            catch (DbUpdateConcurrencyException)
            {
                TempData["aaerror"] = "unable to update";

            }

            return RedirectToPage("./Index");
        }

        private bool GaurantorAccountExists(long id)
        {
            return _context.GaurantorAccounts.Any(e => e.Id == id);
        }
    }
}
