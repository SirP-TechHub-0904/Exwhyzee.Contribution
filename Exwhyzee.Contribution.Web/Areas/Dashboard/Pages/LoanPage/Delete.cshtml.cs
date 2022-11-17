using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exwhyzee.Contribution.Domain.Models;
using Exwhyzee.Contribution.Web.Data;

namespace Exwhyzee.Contribution.Web.Areas.Dashboard.Pages.LoanPage
{
    public class DeleteModel : PageModel
    {
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public DeleteModel(Exwhyzee.Contribution.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Loan Loan { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loan = await _context.Loans
                .Include(l => l.Profile).FirstOrDefaultAsync(m => m.Id == id);

            if (Loan == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loan = await _context.Loans.FindAsync(id);

            if (Loan != null)
            {
                _context.Loans.Remove(Loan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
