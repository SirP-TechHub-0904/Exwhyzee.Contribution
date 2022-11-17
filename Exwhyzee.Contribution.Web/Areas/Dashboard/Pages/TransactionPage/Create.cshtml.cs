using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.TransactionPage
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
        ViewData["ProfileId"] = new SelectList(_context.Set<Profile>(), "Id", "Fullname");
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();
            TempData["aasuccess"] = "Account created successfully";

            return RedirectToPage("./Index");
        }
    }
}
