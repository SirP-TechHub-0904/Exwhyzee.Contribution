using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.GaurantorPage
{
    public class CreateModel : PageModel
    {
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public CreateModel(Exwhyzee.Contribution.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GaurantorId"] = new SelectList(_context.Set<Profile>(), "Id", "Fullname");
        ViewData["ProfileId"] = new SelectList(_context.Set<Profile>(), "Id", "Fullname");
            return Page();
        }

        [BindProperty]
        public GaurantorAccount GaurantorAccount { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            GaurantorAccount.Date = DateTime.UtcNow.AddHours(1);
            //if (!ModelState.IsValid)
            //{
            //    ViewData["GaurantorId"] = new SelectList(_context.Set<Profile>(), "Id", "Fullname");
            //    ViewData["ProfileId"] = new SelectList(_context.Set<Profile>(), "Id", "Fullname");

            //    return Page();
            //}
            
            _context.GaurantorAccounts.Add(GaurantorAccount);
            await _context.SaveChangesAsync();
            TempData["aasuccess"] = "Account created successfully";

            return RedirectToPage("./Index");
        }
    }
}
