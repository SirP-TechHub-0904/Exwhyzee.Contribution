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
    public class IndexModel : PageModel
    {
        private readonly Exwhyzee.Contribution.Web.Data.ApplicationDbContext _context;

        public IndexModel(Exwhyzee.Contribution.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get;set; }

        public async Task OnGetAsync()
        {
            Loan = await _context.Loans
                .Include(l => l.Profile).ToListAsync();
        }
    }
}
